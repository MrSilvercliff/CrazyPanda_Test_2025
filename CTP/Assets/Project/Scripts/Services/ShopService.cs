using UnityEngine;

namespace RedPanda.Project
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
