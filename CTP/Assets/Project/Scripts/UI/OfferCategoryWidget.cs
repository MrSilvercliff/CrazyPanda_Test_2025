using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RedPanda.Project
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
                 * But have not so much time, so heck it
                 */
                var newWidget = Instantiate(_offerWidgetPrefab, _offerWidgetsContainer);
                newWidget.Setup(offerModel);
                newWidget.gameObject.SetActive(true);
                _widgets[offerModel] = newWidget;
            }
        }
    }
}
