using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.UI.Events;
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
            var buyLimitReached = offerModel.IsBuyLimitReached();

            if (buyLimitReached)
            {
                Debug.LogError($"CANT BUY OFFER, BUY LIMIT REACHED!");
                return;
            }

            var offerCost = offerModel.Config.Cost;
            var hasCurrency = GameController.User.HasCurrency(offerCost);

            if (!hasCurrency)
            {
                Debug.LogError($"CANT BUY OFFER, NOT ENOUGH CURRENCY!");
                return;
            }

            Debug.Log($"Buying offer [{offerModel.Config.Id}] [{offerModel.Config.Title}]");

            GameController.User.SpendCurrency(offerCost);
            offerModel.OnBuy();

            var evnt = new OfferBuySuccessEvent(offerModel);
            GameController.EventBus.Fire(evnt);
        }
    }
}
