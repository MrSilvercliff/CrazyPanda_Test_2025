using RedPanda.Project.Scripts.Extensions;
using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Interfaces;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.UI.Events;
using RedPanda.Project.Scripts.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.Views
{
    public class ShopView : MonoBehaviour, IInitializable
    {
        [SerializeField] private CurrencyWidget _currencyWidget;
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private Transform _categoryWidgetContainer;

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
            var pool = GameCore.Instance.OfferCategoryWidgetPool;

            foreach (var offerByTypeItem in offersByType)
            {
                var offerType = offerByTypeItem.Key;
                var offerModels = offerByTypeItem.Value;

                if (_offerCategoryWidgets.ContainsKey(offerType))
                    continue;

                var newWidget = pool.Spawn();
                newWidget.Setup(offerType, offerModels, _scrollRect);
                newWidget.transform.SetParent(_categoryWidgetContainer);
                newWidget.transform.ResetLocalPosition();
                newWidget.transform.ResetLocalRotation();
                newWidget.transform.ResetLocalScale();
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
