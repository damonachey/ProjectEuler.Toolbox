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
            max += 2; // to account for zero base

            if (max > _lastSmallestFactor)
            {
                lock (_smallestFactorsLock)
                {
                    _smallestFactors = new int[max / 2];

                    for (int i = 0; i < max / 2; i++)
                    {
                        _smallestFactors[i] = 1;
                    }

                    for (int i = 3; i < max; i += 2)
                    {
                        if (_smallestFactors[i / 2] == 1)
                        {
                            for (int k = i + i; k < max; k += i)
                                if (k % 2 == 1 && _smallestFactors[k / 2] == 1)
                                {
                                    _smallestFactors[k / 2] = i;
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

            var f = 
                n == 2 ? 1 : 
                n % 2 == 0 ? 2 : 
                _smallestFactors[n / 2];

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