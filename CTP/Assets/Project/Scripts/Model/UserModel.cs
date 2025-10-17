using System;

namespace RedPanda.Project
{
    public sealed class UserModel
    {
        public int Currency { get; private set; }

        private const int CurrencyRegenRatePerSecond = 25; // TODO
        private const int CurrencyMaxLimit = 1000; // TODO

        public UserModel()
        {
            Currency = CurrencyMaxLimit;
        }

        public void AddCurrency(int delta)
        {
            throw new NotImplementedException();
        }

        public void SpendCurrency(int delta)
        {
            throw new NotImplementedException();
        }

        public bool HasCurrency(int amount)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            // TODO
        }
    }
}