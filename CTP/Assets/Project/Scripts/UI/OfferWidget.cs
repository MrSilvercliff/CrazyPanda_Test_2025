using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.UI.Events;
using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI
{
    public class OfferWidget : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private Image _backImage;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _priceIconImage;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _buyButton;

        private OfferModel _offerModel;

        private void OnEnable()
        {
            GameCore.Instance.EventBus.Subscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
        }

        private void OnDisable()
        {
            GameCore.Instance.EventBus.UnSubscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
        }

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
            {
                gameObject.SetActive(false);
                return;
            }

            gameObject.SetActive(true);

            var shopConfig = GameCore.Instance.ShopConfig;
            var raritySettings = shopConfig.GetRaritySettings(_offerModel.Config.Rarity);

            RefreshTitle(raritySettings);
            RefreshBackImage(raritySettings);
            RefreshIcon();
            RefreshPriceText();
            RefreshHasCurrency();
        }

        private void RefreshTitle(ShopConfig.RaritySettingsItem raritySettingsItem)
        {
            _titleText.fontMaterial = raritySettingsItem.TitleFontMaterial;
            _titleText.text = _offerModel.Config.Title;
        }

        private void RefreshBackImage(ShopConfig.RaritySettingsItem raritySettingsItem)
        {
            _backImage.sprite = raritySettingsItem.BackSprite;
        }

        private void RefreshIcon()
        {
        }

        private void RefreshPriceText()
        {
            _priceText.text = $"x{_offerModel.Config.Cost}";
        }

        private void RefreshHasCurrency()
        {
            var shopConfig = GameCore.Instance.ShopConfig;
            var hasCurrency = GameCore.Instance.User.HasCurrency(_offerModel.Config.Cost);
            _buyButton.interactable = hasCurrency;

            if (hasCurrency)
            {
                _titleText.color = Color.white;
                _backImage.material = null;
                _iconImage.material = null;
                _priceIconImage.material = null;
                _priceText.color = shopConfig.PriceTextFontColor;
            }
            else
            {
                _titleText.color = shopConfig.GreyScaleFontColor;
                _backImage.material = shopConfig.GreyScaleMaterial;
                _iconImage.material = shopConfig.GreyScaleMaterial;
                _priceIconImage.material = shopConfig.GreyScaleMaterial;
                _priceText.color = shopConfig.GreyScaleFontColor;
            }
        }

        private void OnBuyButtonClick()
        {
            GameCore.Instance.ShopService.TryBuy(_offerModel);
        }

        private async Task OnCurrencyChangeEvent(CurrencyChangeEvent @event)
        {
            RefreshHasCurrency();
        }
    }
}
