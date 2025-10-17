using System;

namespace RedPanda.Project
{
    public sealed class OfferModel
    {
        public OfferConfig Config { get; private set; }
        public int BuyCount { get; private set; }

        public OfferModel(OfferConfig config)
        {
            Config = config;
        }

        public void Buy()
        {
            if (BuyCount >= Config.BuyLimit)
            {
                throw new InvalidOperationException();
            }

            BuyCount++;
        }
    }
}