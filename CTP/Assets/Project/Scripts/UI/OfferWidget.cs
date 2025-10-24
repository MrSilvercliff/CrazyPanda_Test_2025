using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project
{
    public class OfferWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Image _backImage;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _buyButton;

        private OfferModel _offerModel;

        private void Awake()
        {
            _buyButton.onClick.AddListener(OnBuyButtonClick);
        }

        public void Setup(OfferModel offerModel)
        {
            _offerModel = offerModel;
            Refresh();
        }

        private void Refresh()
        {
            if (_offerModel == null)
                return;

            RefreshTitle();
            RefreshBackImage();
            RefreshIcon();
            RefreshPriceText();
        }

        private void RefreshTitle()
        { 
            _titleText.text = _offerModel.Config.Title;
        }

        private void RefreshBackImage()
        { 
        }

        private void RefreshIcon()
        { 
        }

        private void RefreshPriceText()
        {
            _priceText.text = $"x{_offerModel.Config.Cost}";
        }

        private void OnBuyButtonClick()
        {
            Game.ShopService.TryBuy(_offerModel);
        }
    }
}
