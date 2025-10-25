using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RedPanda.Project
{
    public interface ISpriteConfig
    {
        AssetReferenceSprite GetOfferIconByName(string iconName);
    }

    [CreateAssetMenu(fileName = "SpriteConfig", menuName = "Configs/Sprite Config")]
    public class SpriteConfig : ScriptableObject, ISpriteConfig
    {
        [SerializeField] private AssetReferenceSprite[] _offerIcons;

        public AssetReferenceSprite GetOfferIconByName(string iconName)
        {
            AssetReferenceSprite result = null;

            foreach (var offerIcon in _offerIcons)
            {
                if (offerIcon.Asset.name == iconName)
                { 
                    result = offerIcon;
                    break;
                }
            }

            if (result == null)
                Debug.LogError($"OFFER ICON WITH NAME [{iconName}] NOT FOUND!");

            return result;
        }
    }
}
