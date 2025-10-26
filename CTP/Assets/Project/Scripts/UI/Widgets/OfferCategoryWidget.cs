using RedPanda.Project.Scripts.Extensions;
using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Interfaces;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.ObjectPool;
using RedPanda.Project.Scripts.UI.UtilWigets;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.Widgets
{
    public class OfferCategoryWidget : MonoBehaviour, IPoolable
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private ScrollRect _offerWidgetScrollRect;
        [SerializeField] private Transform _offerWidgetsContainer;
        [SerializeField] private HybridScrollRectDragWidget _hybridScrollRectDragWidget;

        private Dictionary<OfferModel, OfferWidgetHybridScrollDrag> _widgets;

        public void OnCreate()
        {
            _widgets = new();
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
        }

        public void Setup(OfferType offerType, IReadOnlyList<OfferModel> offerModels, ScrollRect viewScrollRect)
        {
            RefreshScrollRects(viewScrollRect);
            RefreshTitle(offerType);
            RefreshOfferWidgets(offerModels, viewScrollRect);
        }

        public void OnOfferBuy(OfferModel offerModel)
        {
            CheckOfferBuyLimit(offerModel);
        }

        private void RefreshScrollRects(ScrollRect viewScrollRect)
        { 
            _hybridScrollRectDragWidget.Setup(viewScrollRect, _offerWidgetScrollRect);
        }

        private void RefreshTitle(OfferType offerType)
        {
            _titleText.text = offerType.ToString();
        }

        private void RefreshOfferWidgets(IReadOnlyList<OfferModel> offerModels, ScrollRect viewScrollRect)
        {
            var pool = GameCore.Instance.OfferWidgetHybridScrollDragObjectPool;

            foreach (var offerModel in offerModels)
            {
                if (_widgets.ContainsKey(offerModel))
                    continue;

                var newWidget = pool.Spawn();
                newWidget.transform.SetParent(_offerWidgetsContainer);
                newWidget.transform.ResetLocalPosition();
                newWidget.transform.ResetLocalRotation();
                newWidget.transform.ResetLocalScale();
                newWidget.Setup(offerModel);
                newWidget.Setup(viewScrollRect, _offerWidgetScrollRect);
                newWidget.gameObject.SetActive(true);
                _widgets[offerModel] = newWidget;
            }
        }

        private void CheckOfferBuyLimit(OfferModel offerModel)
        {
            if (!_widgets.TryGetValue(offerModel, out var widget))
                return;

            var isBuyLimitReached = offerModel.IsBuyLimitReached();

            if (!isBuyLimitReached)
                return;

            var pool = GameCore.Instance.OfferWidgetHybridScrollDragObjectPool;
            pool.Despawn(widget);
            _widgets.Remove(offerModel);
        }
    }
}
