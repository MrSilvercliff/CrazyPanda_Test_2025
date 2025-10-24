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
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Button _buyButton;

        private OfferModel _offerModel;

        private void OnEnable()
        {
            GameController.Instance.EventBus.Subscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
        }

        private void OnDisable()
        {
            GameController.Instance.EventBus.UnSubscribe<CurrencyChangeEvent>(OnCurrencyChangeEvent);
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

            var shopConfig = GameController.Instance.ShopConfig;
            var raritySettings = shopConfig.GetRaritySettings(_offerModel.Config.Rarity);

            RefreshTitle(raritySettings);
            RefreshBackImage(raritySettings);
            RefreshIcon();
            RefreshPriceText();
            RefreshHasCurrency(shopConfig, raritySettings);
        }

        private void RefreshTitle(ShopConfig.RaritySettingsItem raritySettingsItem)
        {
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

        private void RefreshHasCurrency(IShopConfig shopConfig, ShopConfig.RaritySettingsItem raritySettingsItem)
        {
            var hasCurrency = GameController.Instance.User.HasCurrency(_offerModel.Config.Cost);
            _buyButton.interactable = hasCurrency;

            if (hasCurrency)
            {
                _titleText.fontMaterial = raritySettingsItem.TitleFontMaterial;
                _priceText.fontMaterial = shopConfig.PriceTextFontMaterial;
            }
            else
            {
                _titleText.fontMaterial = shopConfig.GrayScaleFontMaterial;
                _priceText.fontMaterial = shopConfig.GrayScaleFontMaterial;
            }
        }

        private void OnBuyButtonClick()
        {
            GameController.Instance.ShopService.TryBuy(_offerModel);
        }

        private async Task OnCurrencyChangeEvent(CurrencyChangeEvent @event)
        {
            var shopConfig = GameController.Instance.ShopConfig;
            var raritySettings = shopConfig.GetRaritySettings(_offerModel.Config.Rarity);
            RefreshHasCurrency(shopConfig, raritySettings);
        }
    }
}
