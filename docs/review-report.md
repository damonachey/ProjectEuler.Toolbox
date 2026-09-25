# ProjectEuler.Toolbox — Code Accuracy & Test Coverage Review

Date: 2026-09-24 (revision 2)

**Methodology:** Every source file and test file in `Toolbox` and `ToolboxTests` was read in full. Coverage is coverlet output from `dotnet test --collect:"XPlat Code Coverage"` (line rate; coverlet produces essentially no branch data).

**Revision history:**
- **R1** (2026-09-24, commit `b084dc7`): initial full review — 342 tests, 83.0% line coverage, findings below.
- **R2** (this revision): refresh after the approved priority items 2–9 were fixed (commits `72284bb`, `58f6cd2`, `584d282`, `a25feb3`, `f224821`, `804878f`, `312f7c2`, `95ee75f`). Completed items are marked **DONE** with commit refs; everything listed as *still open* was re-verified against the current code on this date. **475 tests, 88.22% line coverage.**

---

## Headline numbers (R2)

- **475 tests, 0 failures** (was 342 / 83.0% at R1). Some tests remain flaky (item 11, detailed below).
- **88.22% overall line coverage.** The remaining deficit is concentrated in: `LapJV` (0%), `QuickLZ` (61.2%), `Totient` (91.6%), `HungarianAlgorithm` (99.1%), plus two single "unreachable tail" lines in `PowersAndRoots` (98.5%) and the `CountInBase` iterator (96.3%) that are structurally unreachable and accepted.
- **No test file at all** for `QuickLZ` (vendored, reaches 61.2% only via `CompressedQueue`).
- **0% covered public API:** `LapJV.FindAssignments` (216 lines).

## Coverage summary by class (R2)

| Class | Line cov | Status |
|---|---|---|
| ArrayExtensions, Base, BigRational(+iters), BigRationalExtensions, Combinatorics, CompressedQueue, Dice, Expression, Factorization, Hashing, **LinqExtensions**, MathLibrary, Memoization, NumericExtensions, Packing, Parsers, PathFinding, Polynomial, PrimeHelper, Similarity, StringExtensions, Sudoku, TupleExtensions, Triangle2Extensions, all Geometry types except Geometry.cs, Geometry.cs,  | **100%** | items 2–6, 8, 9 brought these to 100% |
| HungarianAlgorithm | 99.1% | still open (mutates caller's matrix) |
| PowersAndRoots | 98.5% | accepts: single loop-cap tail line (item 5) |
| MathLibrary.CountInBase iterator | 96.3% | accepts: single never-exiting-loop tail line (item 9) |
| Totient | 91.6% | `MinNOverPhiN` heuristic still open (item 7 remainder) |
| QuickLZ (vendored) | 61.2% | still open (item 10) |
| LinearAssignmentProblem (LapJV) | **0%** | still open (item 1) |

---

## Completed since R1 (with fixes)

| # | Area | Fix (commit) |
|---|---|---|
| 2 | **LINQExtensions** | `RandomSample` rewritten as proper single-enumeration **reservoir sampling** (uniform subset, source order); `TrySelect` now takes an `errorHandler` callback instead of appending to a **global static `Errors` list** (state leakage gone); `Merge`/`MergeRepeatLast`/`BinarySearchForMatch`/`SecondLast`/… all covered. 100% line. (`72284bb`) |
| 3 | **PathFinding** | AStar: dead reparenting branch removed — better paths now actually update `cameFrom` (true shortest path); `start == goal` yields immediately instead of `KeyNotFoundException`; Dijkstra NRE on unreachable nodes fixed. (`58f6cd2`) |
| 4 | **Sudoku** | Final validation now checks **digit uniqueness** in row/col/box (a puzzle full of 5s no longer passes); invalid input values rejected. 413 tests. (`584d282`) |
| 5 | **PowersAndRoots.Sqrt(decimal) + Dice** | `Sqrt` bounded to 20 Newton iterations with fixed-point/2-cycle detection returning the closer value — proven hang input `Sqrt(40000000000000000000000000003m)` (2-cycles, 2000+ iterations) now terminates. `Dice.PossibleRolls(0, sides)` yields one empty combination; `dice < 0` throws. (`a25feb3`) |
| 6 | **Geometry** | `TriangleThirdPoint` 0% → 100% (docs, `Argument*` guards, triangle-existence validation, `T.Max` radicand clamp); `Rectangles` dead code removed + computed in **checked `long`** (throws `OverflowException` beyond `long`, was silent `int` overflow); `Triangle2Extensions` gained exact `DoubledArea<T>` and `Area` truncation documented. (`f224821`) |
| 7 (part) | **Totient.Phi2** | `Phi2(0)` infinite loop fixed: `n < 1` throws `ArgumentOutOfRangeException` (matches `Phi`'s out-of-range pattern). (`804878f`) |
| 8 | **Polynomial.Lagrange + ReduceRomanNumeral** | `Lagrange` int truncation: per-term integer division produced wrong interpolations (`-34` instead of `125` for the cube at `x=5`); integral `T` now computes exactly in `BigInteger` (basis denominators, lcm, single final division; truncates toward zero only for genuinely fractional values). Floating path byte-identical. `ReduceRomanNumeral` one-pass chain produced non-minimal output (`"IIIIII"→"IVII"`, 2153→13-char `"MCMCXCXLXIXIV"`); now parses the additive value (subtractive rule) and re-emits canonical minimal form (`"IIIIII"→"VI"`, 2153→`"MMCLIII"`). (`312f7c2`) |
| 9 | **Factorization + MathLibrary** | Negatives: `PrimeFactors(-8)` yielded `[2,2,2,-1]`, `FactorCount(-2)` returned 4 — all now throw `ArgumentOutOfRangeException`. `GCD(int.MinValue, 4)` threw on `Math.Abs` (answer 4) — signed-Euclid rewrite, `int` computes in `long`. `LCM(65537,32768)` silently wrapped to `-2147450880` — `long` math + `checked`. MathLibrary: `Factorial(-n)` no longer silently returns 1; `IsPalindrome("")` no longer throws (empty = `true`); `Binomial(0,0)=1` now reachable; `CountInBase` digit count derived so no value exceeds `long.MaxValue` (radix 10 no longer wraps); `CycleLength` now returns the **repetend length** (`(1,7)=6` not 7; `(1,452)=112` not the pinned 115). (`95ee75f`) |

---

## Still open — re-verified on 2026-09-24

### 1. `LinearAssignmentProblem.LapJV` — 0% coverage (biggest exposed risk)
216 lines, still 0% line coverage, with a single LAP test pinning `{4,1,2,3,0}` on a 5×5 negative-cost grid. The big-`n` fast path is entirely unverified.
- `HungarianAlgorithm.FindAssignments` still **mutates the caller's cost matrix** (undocumented side effect) — the one existing test passes a freshly built matrix, so the copy-behavior contract is untested (99.1% line).

### 7 (remainder). `PrimeHelper` portability + `Totient.MinNOverPhiN`
- `PrimeHelper.cs` line 5 still hard-codes `C:\Users\damon\uSync\Development\Data\Primes32bit.bin` — the suite silently depends on a machine-local data file. `PrimesMax` streams ~5 M primes from disk (slow).
- `Totient.MinNOverPhiN` (line 160) still returns the **largest product of two primes below `n`** — a heuristic, not the true minimizer of `N/φ(N)` (which is a primorial/product of small primes), and it relies on `PrimeHelper.Primes()` ordering (same file-path dependency). Untested.

### 10. `QuickLZ` (61.2%, vendored, no own tests)
Only exercised through `CompressedQueue`; no `QuickLZTests.cs` exists. If inputs never trigger compression corner cases (incompressible data, literals-only blocks), large parts of the codec are untested. Recommend a round-trip corpus test or accept as-is (vendored).

### 11. Test hygiene (flaky tests + cosmetic)
- `ArrayExtensionsTests.ToArrayPerformanceTest` — asserts `sw1.Elapsed < sw2.Elapsed` on a **10-element** array (a timer comparison) — flaky by nature (re-verified present).
- `Dice.MeteredRollsOneDie/MultipleDice` — tolerance ≈ ±0.028σ (100,000 rolls, relative 0.0002) — flaky; `MeteredRollsMultipleDice` failed once in a full run, passes 5/5 in isolation (historically documented).
- `StringExtensionsTests.TestRandomString` — `RandomString()` defaults to `Random.Shared.Next(132)` chars, i.e. can return **empty**; two empty strings pass `Assert.NotEqual` with each other → fails only if both are empty (~1/132², but real).
- `Dice.RandomRolls*` — the in-code comment says "0.02% from expected" but the assert is `< 0.02` (i.e. **2%**) — comment misleads; the assert itself is effectively never flaky.
- `HashingTests.EvaluateRPN` (line 20) — the FNV-64 test is still misnamed `EvaluateRPN` (copy-paste from ExpressionTests; cosmetic).
- `BigRationalExtensionsTests` — `ToBigRationalsIrrational`/`ToBigRationalsIrrationalTest2` and `ToBigRationalsPerfectSquareTest1`/`ToBigRationalsPerfectSquareTest3` are exact duplicates (re-verified present).

### Secondary findings (re-verified, lower priority)
- **Expression** — `Evaluate`/`EvaluateRPN` use `double.Parse` with the current culture (breaks on comma decimal separators) and `Evaluate` explicitly ignores operator precedence (docs say *must* parenthesize). Still open.
- **BigRational** — `Pow(…, negative exponent)` throws but is **untested** (tested exponents: 2, 3, 3 positive); implicit `double`/decimal conversion is culture-dependent (route through `ToLongString`); `Sqrt` convergent-ratio heuristic precision undocumented; `ToDecimalString` truncates by design (`"0.00"` for 1/300 is pinned) — doc note still missing.
- **Base.Convert** — little-endian-first digit order still undocumented; untested for value `0` and radix > 10.
- **Combinatorics.Combinations(k > n)** — still throws `IndexOutOfRangeException` (`sa[k-1]` on a too-short array) instead of a clear argument error.
- **Packing.Knapsack** — docs promise "closest to but not exceeding" but the code requires an exact sum and throws `InvalidOperationException` on unreachable targets; the throw path is untested.
- **Geometry** — `Circle2Extensions.ChordAngle` still has no domain validation (`radius == 0` or `length > 2r` → NaN, untested); `Line2Extensions` still divides by zero on vertical lines (`P2.X == P1.X`) with no guard/test; `Ellipse2` `b > a` throw path and `a == b` (circle) untested.
- **Geometry.cs** — `PythagoreanTriples` uses `double` `sqrt` bounds on an integer loop (off-by-one risk near perfect squares) and `int` arithmetic that can overflow at very large perimeters; `Diamonds` is an O(w²·h²) quad loop with `double` stepping (slow at scale) — both only pinned at single values.
- **PathFinding** — AStar excludes the start cell's weight while Dijkstra counts it (inconsistent definitions) — **deliberately left as-is** (documented at item 3).
- **CountInBase (new at R2)** — discovered during item 9: the counter **cycles forever**. On overflow the most-significant digit resets to `0`, so the `n[c-1] != b` stop condition can never fire; every base-b c-digit number repeats indefinitely. Item 9 fixed only the overflow (values never exceed `long.MaxValue`); the infinite-cycle semantic is preserved and now documented in the XML doc, but its usefulness (vs. terminating after one cycle) is an open design question.

## Accepted / deliberately not changed
- `PowersAndRoots` 98.5% and `CountInBase` iterator 96.3%: single structurally-unreachable loop-cap tail lines (documented in each fix).
- `Triangle2Extensions.Area` truncates for integral `T` — by design, documented; exact `DoubledArea<T>` provided instead.
- AStar/Dijkstra start-weight inconsistency — documented, no behavior change.

---

## Suggested priority order (remaining work)

1. `LapJV` — 216 lines, 0% coverage (biggest exposed risk) + `HungarianAlgorithm` cost-matrix mutation contract.
2. `PrimeHelper` portability (hard-coded data path) + `Totient.MinNOverPhiN` heuristic (item 7 remainder).
3. `QuickLZ` round-trip corpus test (only if the vendored code is intended to stay).
4. Flaky-test hardening (`ToArrayPerformanceTest`, `MeteredRolls*`, `TestRandomString`) + cosmetic renames/duplicates (cheap, improves CI reliability).
5. Secondary findings: `Expression` culture/precedence, `BigRational.Pow` negative-exponent test + culture note, `Base.Convert` docs, `Combinations(k>n)`, `Packing.Knapsack` throw-path test, `ChordAngle`/`Line2Extensions` domain validation, `PythagoreanTriples`/`Diamonds` robustness, `CountInBase` termination semantics.