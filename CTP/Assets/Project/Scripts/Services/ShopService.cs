using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.UI.Events;
using UnityEngine;

namespace RedPanda.Project.Scripts.Services
{
    public interface IShopService
    {
        IShopModel ShopModel { get; }
        void TryBuy(OfferModel offerModel);
    }

    public class ShopService : IShopService
    {
        public IShopModel ShopModel { get; }

        public ShopService()
        { 
            ShopModel = new ShopModel();
        }

        public void TryBuy(OfferModel offerModel)
        {
            var buyLimitReached = offerModel.IsBuyLimitReached();

            if (buyLimitReached)
            {
                Debug.LogError($"CANT BUY OFFER, BUY LIMIT REACHED!");
                return;
            }

            var user = GameCore.Instance.User;

            var offerCost = offerModel.Config.Cost;
            var hasCurrency = user.HasCurrency(offerCost);

            if (!hasCurrency)
            {
                Debug.LogError($"CANT BUY OFFER, NOT ENOUGH CURRENCY!");
                return;
            }

            Debug.Log($"Buying offer [{offerModel.Config.Id}] [{offerModel.Config.Title}]");

            user.SpendCurrency(offerCost);
            offerModel.OnBuy();

            var evnt = new OfferBuySuccessEvent(offerModel);
            GameCore.Instance.EventBus.Fire(evnt);
        }
    }
}
