using RedPanda.Project.Scripts.Interfaces;
using RedPanda.Project.Scripts.Model;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.Scripts.UI
{
    public class OfferCategoryWidget : MonoBehaviour, IInitializable
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Transform _offerWidgetsContainer;
        [SerializeField] private OfferWidget _offerWidgetPrefab;

        private Dictionary<OfferModel, OfferWidget> _widgets;

        public void Init()
        {
            _widgets = new();
        }

        public void Setup(OfferType offerType, IReadOnlyList<OfferModel> offerModels)
        {
            RefreshTitle(offerType);
            RefreshOfferWidgets(offerModels);
        }

        public void OnOfferBuy(OfferModel offerModel)
        {
            CheckOfferBuyLimit(offerModel);
        }

        private void RefreshTitle(OfferType offerType)
        {
            _titleText.text = offerType.ToString();
        }

        private void RefreshOfferWidgets(IReadOnlyList<OfferModel> offerModels)
        {
            foreach (var offerModel in offerModels)
            {
                if (_widgets.ContainsKey(offerModel))
                    continue;

                /*
                 * Better use object pooling
                 * But dont have so much time, so heck it
                 */
                var newWidget = Instantiate(_offerWidgetPrefab, _offerWidgetsContainer);
                newWidget.Setup(offerModel);
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

            /*
             * Better user object pooling and return widget to pool
             * But dont have so much time, so heck it x2
             */
            widget.gameObject.SetActive(false);
        }
    }
}
