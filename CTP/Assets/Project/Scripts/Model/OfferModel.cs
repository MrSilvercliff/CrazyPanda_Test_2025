using System;

namespace RedPanda.Project.Scripts.Model
{
    public sealed class OfferModel
    {
        public OfferConfig Config { get; private set; }
        public int BuyCount { get; private set; }

        public OfferModel(OfferConfig config)
        {
            Config = config;
        }

        public void OnBuy()
        {
            BuyCount++;
        }
    }
}