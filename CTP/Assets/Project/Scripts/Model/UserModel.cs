using RedPanda.Project.Scripts.Interfaces;
using System;

namespace RedPanda.Project.Scripts.Model
{
    public sealed class UserModel : IMonoUpdatable
    {
        public int Currency { get; private set; }

        private const int CurrencyRegenRatePerSecond = 25; // TODO
        private const int CurrencyMaxLimit = 1000; // TODO

        private float _currencyRegenSecondProgress;

        public UserModel()
        {
            Currency = CurrencyMaxLimit;
            _currencyRegenSecondProgress = 0f;
        }

        public void AddCurrency(int delta)
        {
            Currency += delta;

            if (Currency >= CurrencyMaxLimit)
                Currency = CurrencyMaxLimit;
        }

        public void SpendCurrency(int delta)
        {
            Currency -= delta;

            if (Currency < 0)
                Currency = 0;
        }

        public bool HasCurrency(int amount)
        {
            var result = Currency >= amount;
            return result;
        }

        public void OnUpdate(float deltaTime = 0)
        {
            _currencyRegenSecondProgress += deltaTime;

            if (_currencyRegenSecondProgress < 1f)
                return;

            _currencyRegenSecondProgress = 0f;
            AddCurrency(CurrencyRegenRatePerSecond);
        }
    }
}