using System;

namespace RedPanda.Project.Scripts.Model
{
    public sealed class OfferModel
    {
        public OfferConfig Config { get; private set; }

        private int _buyCount;

        public OfferModel(OfferConfig config)
        {
            Config = config;
            _buyCount = 0;
        }

        public void OnBuy()
        {
            _buyCount++;
        }

        public bool IsBuyLimitReached()
        { 
            var result = _buyCount >= Config.BuyLimit;
            return result;
        }
    }
}