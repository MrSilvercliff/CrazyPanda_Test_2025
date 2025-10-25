using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RedPanda.Project.Scripts.Configs
{
    public interface IAddressablesConfig
    {
        AssetReferenceGameObject ShopView { get; }
        ISpriteConfig SpriteConfig { get; }
    }

    [CreateAssetMenu(fileName = "AddressablesConfig", menuName = "Configs/Addressables Config")]
    public class AddressablesConfig : ScriptableObject, IAddressablesConfig
    {
        public AssetReferenceGameObject ShopView => _shopView;
        public ISpriteConfig SpriteConfig => _spriteConfig;

        [SerializeField] private AssetReferenceGameObject _shopView;
        [SerializeField] private SpriteConfig _spriteConfig;
    }
}
