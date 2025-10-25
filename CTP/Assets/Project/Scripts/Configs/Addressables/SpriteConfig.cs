using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RedPanda.Project
{
    public interface ISpriteConfig
    {
        AssetReference GetOfferIconByName(string iconName);
    }

    [CreateAssetMenu(fileName = "SpriteConfig", menuName = "Configs/Sprite Config")]
    public class SpriteConfig : ScriptableObject, ISpriteConfig
    {
        [SerializeField] private AssetReferenceWithName[] _offerIcons;

        public AssetReference GetOfferIconByName(string iconName)
        {
            AssetReference result = null;

            foreach (var offerIcon in _offerIcons)
            {
                if (offerIcon.Name == iconName)
                { 
                    result = offerIcon.AssetReference;
                    break;
                }
            }

            if (result == null)
                Debug.LogError($"OFFER ICON WITH NAME [{iconName}] NOT FOUND!");

            return result;
        }

        [Serializable]
        public class AssetReferenceWithName
        {
            public string Name => _name;
            public AssetReference AssetReference => _assetReference;

            [SerializeField] private string _name;
            [SerializeField] private AssetReference _assetReference;
        }
    }
}
