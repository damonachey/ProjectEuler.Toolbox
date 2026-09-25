# ProjectEuler.Toolbox — Code Accuracy & Test Coverage Review

Date: 2026-09-24

**Methodology:** Every source file and test file in `Toolbox` and `ToolboxTests` was read in full. Coverage is measured coverlet output from `dotnet test --collect:"XPlat Code Coverage"` (line rate; coverlet produced essentially no branch data). Findings are code review only — no code was changed.

## Headline numbers

- **342 tests, 0 failures** — but flaky tests exist (detailed below).
- **83.0% overall line coverage.** Most of the deficit is concentrated in 5 spots: `LapJV` (0%), `LINQExtensions` (25%), `QuickLZ` (61%), `Geometry.cs` (79%), `Sudoku` (84%).
- **No test files at all** for `LinqExtensions` and `QuickLZ`. `LinearAssignmentProblemTests` has a single test.
- **0% covered public API:** `LapJV.FindAssignments`, `LINQExtensions.Merge`, `.RandomSample`, `.TrySelect`, `Geometry.TriangleThirdPoint`.

## Coverage summary by class

| Class | Line cov | Notes |
|---|---|---|
| ArrayExtensions, Base, BigRational(+iters), BigRationalExtensions, Combinatorics, CompressedQueue, Dice, Expression, Factorization, Hashing, MathLibrary, Memoization, NumericExtensions, Packing, Parsers, PathFinding (most), Polynomial, PowersAndRoots, PrimeHelper, Similarity, StringExtensions, TupleExtensions, all Geometry types except Geometry.cs | 100% | |
| HungarianAlgorithm | 99.1% | |
| LINQExtensions.MergeRepeatLast | 84.2% | |
| MathLibrary.CountInBase | 95.2% | |
| PathFinding AStar iterator | 88.7% | |
| Totient | 91.5% | |
| Sudoku | 83.8% | |
| Geometry | 78.8% | `TriangleThirdPoint` 0%, dead code in `Rectangles` |
| QuickLZ (vendored) | 61.2% | only exercised via CompressedQueue |
| LinearAssignmentProblem (LapJV) | **0%** | |
| LINQExtensions (Merge/RandomSample/TrySelect) | **0%** | |

---

## Root folder classes — findings and gaps

### Point classes / TupleExtensions / ArrayExtensions / Hashing / Parsers / Memoization / Similarity / CompressedQueue
Solid: 100% covered, correct, edge cases tested.
- *HashingTests*: the FNV-64 test is named `EvaluateRPN` (copy-paste error, cosmetic).
- *ArrayExtensionsTests.ToArrayPerformanceTest*: asserts elapsed time `sw1 < sw2` on a **10-element** array — flaky by nature, will fail intermittently on CI.
- *StringExtensions.RandomStringTest*: both calls can randomly return empty → weak assertion, flake-prone.

### Base.Convert
Yields nothing for value `0`; digit order is little-endian-first (inherits the `ToDigits` convention) but the doc/xml doesn't say so. Untested for `0` and for radix > 10.

### Combinatorics
`PermutationsDistinct` is correct but only indirectly tested (relies on `LINQExtensions.ReverseRange`, which has no direct tests). `Combinations(k > n)` throws `IndexOutOfRangeException` instead of a clear argument error. `Partitions`/`Permutations` well tested.

### MathLibrary
- `Factorial(-n)` silently returns `1` (should throw or be documented).
- `IsPalindrome("")` throws `IndexOutOfRangeException`.
- `Binomial` forbids `n < 1`, so `C(0,0)=1` is unreachable.
- `CountInBase` overflows for radix ≈ 10 with modest inputs (int arithmetic).
- `CycleLength(1, 7)` returns `7` (counts the initial state); the standard repetend length is `6` — off-by-one semantics, and the test pins `115` for 452 locking in this reading.

### Expression
`Evaluate` (a) parses doubles/BigRationals with the current culture (breaks on non-`en-US` decimal separators), and (b) explicitly ignores operator precedence (docs say *must* parenthesize — dangerous API).

### Packing.Knapsack
Doc comment promises "closest to but not exceeding" but the code requires an *exact* sum and throws `InvalidOperationException` on unreachable targets. Verify the throw path against a test with an unreachable target.

### PowersAndRoots.Sqrt(decimal)
`epsilon = 0m` → converges only when `prev == current` exactly; on some decimals this never terminates. Needs a floor or a non-zero epsilon. Also `Sqrt(-x)` handling untested.

### Polynomial.Lagrange
Uses integer `T` division on term products, so for `int`/`long`/`BigInteger` the interpolation is wrong (truncation); only tested with `double`.

### PrimeHelper
Hard-coded absolute path `C:\Users\damon\uSync\Development\Data\Primes32bit.bin`; the suite silently depends on a machine-local data file (not portable). `PrimesMax` test streams ~5 M primes from disk — slow.

### Totient
- `Phi2(0)` infinite-loops.
- `MinNOverPhiN` returns the largest product of *two primes* `< n`, which is a heuristic, not the true minimizer; and `MaxBelow` correctness relies on `PrimeHelper.Primes()` ordering (same file-path dependency).

### Factorization
- `PrimeFactors(-8)` yields `[2,2,2,-1]`; negative inputs are unhandled.
- `FactorCount(-12)` wrong.
- `GCD(int.MinValue, …)` overflows; `LCM` can silently overflow `int`.

### NumericExtensions.ReduceRomanNumeral
One-pass greedy; not minimal for all inputs (`"IIIIII" → "IVII"` instead of `"VI"`).

### Dice
`PossibleRolls(0, sides)` recurses infinitely. `MeteredRolls` distribution test tolerance is ~±0.028σ (flaky-prone); `RandomRolls` comment says 0.02% but the test asserts 0.02 (2%).

### LINQExtensions (0% on 3 of 4 public methods)
- `TrySelect` appends errors to a **global static `Errors` list** — leaks across tests/threads.
- `RandomSample` re-enumerates via `ElementAt` (O(n²) and incorrect for one-shot enumerables).
- `Merge`/`TrySelect` have **no tests at all**.

### PathFinding.AStar
- **Real bug:** dead-code `if (cameFrom.TryGetValue(neighbor, …) { value = u; }` — a better path never updates the parent, so the reconstructed path is not necessarily the shortest.
- `start == goal` throws `KeyNotFoundException` via `cameFrom[u]`.
- Dijkstra counts the start cell's weight, AStar excludes it — inconsistent definitions.
- Dijkstra NREs (`u` is `default(Coordinate)!`) if unreachable nodes remain in the queue.

### Sudoku (83.8%)
Final validation checks only row/col/box *sums* = 45, not digit uniqueness (a puzzle full of 5s passes). Input not validated. Only one test (`SudokuTests`); harder puzzles untested.

### QuickLZ (61.2%, vendored, no own tests)
Only exercised through `CompressedQueue`. If inputs never trigger compression corner cases (e.g., incompressible data, literals-only blocks), large parts of the codec are untested. Recommend a round-trip corpus test or accept as-is (vendored).

### BigRational (212 lines, 100% line, all branches)
Excellent test suite (1200-line test file: constructors incl. `1/0`, operators, trig to 31 digits, continued fractions, `ToDecimalString` edge cases, PI/E bounds). Findings:
- `Pow` throws on negative exponents — **untested**.
- `Implicit(double)`/decimal parsing route through `ToLongString` → culture-dependent (breaks on comma decimal separators).
- `Sqrt` uses a convergent-ratio heuristic — approximate precision is not documented.
- `ToDecimalString` *truncates* (test pins `"0.00"` for 1/300) — by design, but worth a doc note.

### BigRationalExtensions
Correct (ToBigRationals for √2, perfect squares, e). `ToBigRationalsIrrational`/`…Test2` and `PerfectSquareTest1`/`…Test3` are exact duplicates.

### LinearAssignmentProblem
- **`LapJV` is 216 lines of 0% coverage** with a single LAP test pinning `{4,1,2,3,0}` for a 5×5 negative-cost grid. The big-`n` fast path is completely unverified.
- `HungarianAlgorithm.FindAssignments` **mutates the caller's cost matrix** (undocumented side effect) — the one existing test passes a freshly built matrix, so the copy-behavior contract is untested.

---

## Geometry folder — findings and gaps

### Point2/Point3/Polygon2/Triangle2 (record containers), Point3Extensions (Cross/Dot), Circle2, Circle2Extensions
Functionally correct and fully tested, but:
- *Triangle2Extensions.Area*: `… / T.CreateChecked(2)` truncates for integral `T` — a lattice triangle with odd doubled-area (e.g. `(0,0),(1,1),(0,1)` → real area 0.5) returns **0** for `int`/`long`. Only tested with `double`.
- *Circle2Extensions.ChordAngle*: no domain validation — `radius == 0` or `length > 2r` returns NaN. Untested.

### Line2
Point-slope ctor correctly throws `ArithmeticException` for a point on the y-axis (degenerate); both paths tested.

### Line2Extensions (100% line, 76% branch)
- `Slope`/`YIntercept`/`ReflectPoint` divide by zero on vertical lines (`P2.X == P1.X`): `NaN`/`∞` for `double`, `DivideByZeroException` for `int` — no guard, no test.
- **`Intersects` excludes any intersection that lands on an endpoint** (`l1.P1 != t && … && l2.P2 != t`): two segments that meet exactly at a shared endpoint report `false`. Possibly intentional ("proper crossings only") but undocumented and untested (the existing `IntersectsTrue` deliberately crosses mid-segment).
- The parallel/collinear `d == 0` branch and endpoint-exclusion branches are the untested 24%.

### Ellipse2
Maths correct (area, eccentricity, `h`, Ramanujan perimeter series with correct coefficients through h⁷). Gaps: no test for the `b > a` throw path (line-coverage hides it), no degenerate `a == b` (circle) test, and the series is an approximation (≥ h⁸ terms dropped) — fine for PE use, but note it.

### Geometry.cs (78.8%)
- **`TriangleThirdPoint` at 0%**: enforces undocumented preconditions (`B == origin`, `C.Y == 0`), returns only the positive y-root, and yields NaN when `ba² < x²` (invalid triangle). Needs tests + validation/docs.
- **`Rectangles`**: the real formula `w*(w+1)*h*(h+1)/4` is exact (always divisible by 4) but computed in **`int`** arithmetic inside a `long` method — overflows for `w,h ≳ 46 000`. The old O(n²) loop body after the `return` is **dead code** (this is the `CS0162` warning). Formulae are correct for the tested 77×36 values.
- `TriangleInscribedCircleRadius`: correct formula; **untested**, and yields NaN for invalid triangles (e.g. `a > s`).
- `PythagoreanTriples`: only tested at `maxPerimeter = 42`; uses `double` `sqrt` bounds on an integer loop (off-by-one risk near perfect squares) and `int` arithmetic that can overflow at very large perimeters.
- `Diamonds` is an O(w²·h²)-ish quad loop with `double` stepping — slow at scale; single pinned regression value only.

---

## Test-hygiene / cross-cutting issues

1. **Flaky tests**: `ArrayExtensionsTests.ToArrayPerformanceTest` (10-element timer comparison), `Dice.MeteredRolls` distribution tolerance (~±0.028σ), `StringExtensions.RandomStringTest` (two empties can both pass/"fail" reflexively).
2. **Machine-local dependency**: `PrimeHelper` reads `C:\Users\damon\uSync\Development\Data\Primes32bit.bin` — suite breaks off this machine.
3. **Misnamed test**: HashingTests FNV64 case is `EvaluateRPN`.
4. **Duplicate tests**: BigRationalExtensions irrational & perfect-square cases duplicated.
5. **Static state leakage**: `LINQExtensions.TrySelect` accumulates into a global `Errors` list.
6. **Culture dependence**: double/decimal parsing in `Expression` and `BigRational` conversions assumes `.` decimal separator.

---

## Suggested priority order (fixes only, no code written)

1. `LapJV` — 216 lines, 0% coverage (biggest exposed risk).
2. `LINQExtensions` (global `Errors`, O(n²) `RandomSample`, no tests).
3. `PathFinding.AStar` parent-update bug (real correctness issue) + Dijkstra NRE + start/end edge cases.
4. `Sudoku` validation (sums ≠ uniqueness) + puzzle-input validation + hard-puzzle tests.
5. `PowersAndRoots.Sqrt(decimal)` infinite-loop risk; `Dice.PossibleRolls(0,…)` recursion.
6. `Geometry.TriangleThirdPoint` (0% covered) + `Rectangles` dead code / int overflow + `Triangle2Extensions.Area` int truncation.
7. `PrimeHelper` portability; `Totient.Phi2(0)` infinite loop.
8. `Polynomial.Lagrange` int-truncation; `NumericExtensions.ReduceRomanNumeral` non-minimal output.
9. `Factorization` negatives/GCD overflow; `MathLibrary` edge cases.
10. `QuickLZ` round-trip corpus test (only if the vendored code is intended to stay).
11. Flaky-test hardening + test renames/duplicates (cheap, improves CI reliability).