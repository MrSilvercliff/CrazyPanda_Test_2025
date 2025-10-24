using System.Collections.Generic;
using UnityEngine;

namespace RedPanda.Project
{
    public class ShopView : MonoBehaviour, IInitializable
    {
        [SerializeField] private CurrencyWidget _currencyWidget;
        [SerializeField] private Transform _categoryWidgetContainer;
        [SerializeField] private OfferCategoryWidget _categoryWidgetPrefab;

        private Dictionary<OfferType, OfferCategoryWidget> _offerCategoryWidgets;

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
            var offersByType = Game.Shop.OffersByOfferType;

            foreach (var offerByTypeItem in offersByType)
            {
                var offerType = offerByTypeItem.Key;
                var offerModels = offerByTypeItem.Value;

                if (_offerCategoryWidgets.ContainsKey(offerType)) 
                    continue;

                /*
                 * Better use object pooling
                 * But have not so much time, so heck it
                 */
                var newWidget = Instantiate(_categoryWidgetPrefab, _categoryWidgetContainer);
                newWidget.Init();
                newWidget.Setup(offerType, offerModels);
                newWidget.gameObject.SetActive(true);
                _offerCategoryWidgets[offerType] = newWidget;
            }
        }
    }
}
