using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Interfaces;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.UI.Events;
using RedPanda.Project.Scripts.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace RedPanda.Project.Scripts.UI.Views
{
    public class ShopView : MonoBehaviour, IInitializable
    {
        [SerializeField] private CurrencyWidget _currencyWidget;
        [SerializeField] private Transform _categoryWidgetContainer;
        [SerializeField] private OfferCategoryWidget _categoryWidgetPrefab;

        private Dictionary<OfferType, OfferCategoryWidget> _offerCategoryWidgets;

        private void OnEnable()
        {
            GameCore.Instance.EventBus.Subscribe<OfferBuySuccessEvent>(OnOfferBuySuccessEvent);
        }

        private void OnDisable()
        {
            GameCore.Instance.EventBus.UnSubscribe<OfferBuySuccessEvent>(OnOfferBuySuccessEvent);
        }

        public void Init()
        {
            _offerCategoryWidgets = new();
            _currencyWidget.Init();
            Refresh();
        }

        private void Refresh()
        {
            RefreshCategoryWidgets();
        }

        private void RefreshCategoryWidgets()
        {
            var offersByType = GameCore.Instance.ShopService.ShopModel.OffersByOfferType;

            foreach (var offerByTypeItem in offersByType)
            {
                var offerType = offerByTypeItem.Key;
                var offerModels = offerByTypeItem.Value;

                if (_offerCategoryWidgets.ContainsKey(offerType))
                    continue;

                /*
                 * Better use object pooling
                 * But dont have so much time, so heck it
                 */
                var newWidget = Instantiate(_categoryWidgetPrefab, _categoryWidgetContainer);
                newWidget.Init();
                newWidget.Setup(offerType, offerModels);
                newWidget.gameObject.SetActive(true);
                _offerCategoryWidgets[offerType] = newWidget;
            }
        }

        private async Task OnOfferBuySuccessEvent(OfferBuySuccessEvent evnt)
        {
            var offerModel = evnt.OfferModel;
            var offerType = offerModel.Config.Type;

            if (_offerCategoryWidgets.TryGetValue(offerType, out var widget))
                widget.OnOfferBuy(offerModel);
        }
    }
}
