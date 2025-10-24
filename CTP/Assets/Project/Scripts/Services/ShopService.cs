using RedPanda.Project.Scripts.Model;
using UnityEngine;

namespace RedPanda.Project.Scripts.Services
{
    public interface IShopService
    {
        void TryBuy(OfferModel offerModel);
    }

    public class ShopService : IShopService
    {
        public void TryBuy(OfferModel offerModel)
        {
            var canBuyResult = CanBuyOffer(offerModel);

            if (!canBuyResult)
            {
                Debug.LogError($"CANT BUY OFFER, BUY LIMIT!");
                return;
            }

            var offerCost = offerModel.Config.Cost;
            var hasCurrency = Game.User.HasCurrency(offerCost);

            if (!hasCurrency)
            {
                Debug.LogError($"CANT BUY OFFER, NOT ENOUGH CURRENCY!");
                return;
            }

            Game.User.SpendCurrency(offerCost);
            offerModel.OnBuy();
        }

        private bool CanBuyOffer(OfferModel offerModel)
        {
            var buyCount = offerModel.BuyCount;
            var buyMaxCount = offerModel.Config.BuyLimit;
            var result = buyCount < buyMaxCount;
            return result;
        }
    }
}
