using RedPanda.Project.Scripts.Model;
using System;
using UnityEngine;

namespace RedPanda.Project
{
    public interface IShopConfig
    { 
        ShopConfig.RaritySettingsItem GetRaritySettings(OfferRarity offerRarity);
        Material GreyScaleMaterial { get; }
        Color PriceTextFontColor { get; }
        Color GreyScaleFontColor { get; }
    }

    [CreateAssetMenu(fileName = "RarityConfig", menuName = "Configs/RarityConfig")]
    public class ShopConfig : ScriptableObject, IShopConfig
    {
        public Material GreyScaleMaterial => _greyScaleMaterial;
        public Color PriceTextFontColor => _priceTextFontColor;
        public Color GreyScaleFontColor => _greyScaleFontColor;

        [SerializeField] private RaritySettingsItem[] _raritySettingsItems;
        [SerializeField] private Material _greyScaleMaterial;
        [SerializeField] private Color _priceTextFontColor;
        [SerializeField] private Color _greyScaleFontColor;

        public RaritySettingsItem GetRaritySettings(OfferRarity offerRarity)
        {
            RaritySettingsItem result = null;

            foreach (var rarityItem in _raritySettingsItems)
            {
                if (rarityItem.Rarity == offerRarity)
                { 
                    result = rarityItem;
                    break;
                }
            }

            if (result == null)
                Debug.LogError($"RARITY SETTINGS ITEM FOR RARITY [{offerRarity}] DOES NOT EXIST");

            return result;
        }

        [Serializable]
        public class RaritySettingsItem
        {
            public OfferRarity Rarity => _rarity;
            public Sprite BackSprite => _backSprite;
            public Material TitleFontMaterial => _titleFontMaterial;

            [SerializeField] private OfferRarity _rarity;
            [SerializeField] private Sprite _backSprite;
            [SerializeField] private Material _titleFontMaterial;
        }
    }
}
