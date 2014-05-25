namespace ProjectEuler.Toolbox
{
    public class Totient
    {
        private int[] _smallestFactors;
        private int _lastSmallestFactor;
        private readonly object _smallestFactorsLock;

        public Totient()
        {
            _smallestFactorsLock = new object();
        }

        public Totient(int max)
            : this()
        {
            InitializeSmallestFactors(max);
        }

        /// <summary>
        /// Initialize to the largest n that will be passed to Phi for best performance.
        /// </summary>
        /// <param name="max"></param>
        public void InitializeSmallestFactors(int max)
        {
            max += 1; // to account for zero base

            if (max > _lastSmallestFactor)
            {
                lock (_smallestFactorsLock)
                {
                    _smallestFactors = new int[max];

                    for (int i = 0; i < max; i++)
                    {
                        _smallestFactors[i] = 1;
                    }

                    for (int i = 2; i < max; i++)
                    {
                        if (_smallestFactors[i] == 1)
                        {
                            for (int k = i + i; k < max; k += i)
                                if (_smallestFactors[k] == 1)
                                {
                                    _smallestFactors[k] = i;
                                }
                        }
                    }

                    _lastSmallestFactor = max;
                }
            }
        }

        /// <summary>
        /// the totient of a positive integer n is defined to be the number of positive integers less than or equal to n that are coprime to n (i.e. having no common positive factors other than 1).
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int Phi(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (n >= _lastSmallestFactor)
            {
                InitializeSmallestFactors(n);

                //throw new ArgumentOutOfRangeException("Please InitializeSmallestFactors to a larger value or use PhiSlow(n)");
            }

            var f = _smallestFactors[n];

            if (f == 1)
            {
                return n - 1;
            }

            var fp = 1;

            while ((n /= f) % f == 0)
            {
                fp *= f;
            }

            return Phi(n) * (f - 1) * fp;
        }
    }
}