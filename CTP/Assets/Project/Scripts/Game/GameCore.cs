using RedPanda.Project.Scripts.Configs;
using RedPanda.Project.Scripts.EventBus.Async;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.ObjectPool;
using RedPanda.Project.Scripts.Services;
using RedPanda.Project.Scripts.Services.UnityAddressables;
using RedPanda.Project.Scripts.UI.Widgets;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RedPanda.Project.Scripts.Game
{
    public class GameCore : MonoBehaviour
    {
        public static GameCore Instance { get; private set; }

        public IDOTweenAnimationsConfig DOTweenAnimationsConfig => _doTweenAnimationsConfig;
        public IShopConfig ShopConfig => _shopConfig;
        public IAddressablesConfig AddressablesConfig => _addressablesConfig;

        public IUserModel User { get; private set; }
        public IEventBusAsync EventBus { get; private set; }
        public IShopService ShopService { get; private set; }
        public IAddressablesService AddressablesService { get; private set; }

        public IOfferCategoryWidgetPool OfferCategoryWidgetPool { get; private set; }
        public IOfferWidgetHybridScrollDragObjectPool OfferWidgetHybridScrollDragObjectPool { get; private set; }

        [SerializeField] private DOTweenAnimationsConfig _doTweenAnimationsConfig;
        [SerializeField] private ShopConfig _shopConfig;
        [SerializeField] private AddressablesConfig _addressablesConfig;

        [SerializeField] private ObjectPoolItem _offerCategoryWidgetObjectPoolItem;
        [SerializeField] private ObjectPoolItem _offerWidgetHybridScrollObjectPoolItem;

        private void Awake()
        {
            Instance = this;
            InitServices();
            InitObjectPools();
        }

        private void InitServices()
        {
            User = new UserModel();
            EventBus = new EventBusAsync();
            ShopService = new ShopService();
            AddressablesService = new AddressablesService();
        }

        private void InitObjectPools()
        { 
            InitOfferCategoryWidgetObjectPool();
            InitOfferWidgetHybridScrollObjectPool();
        }

        private void InitOfferCategoryWidgetObjectPool()
        {
            var prefab = _offerCategoryWidgetObjectPoolItem.Prefab;
            var container = _offerCategoryWidgetObjectPoolItem.Container;
            var initCount = _offerCategoryWidgetObjectPoolItem.InitCount;
            OfferCategoryWidgetPool = new OfferCategoryWidgetPool(prefab, container, initCount);
        }

        private void InitOfferWidgetHybridScrollObjectPool()
        {
            var prefab = _offerWidgetHybridScrollObjectPoolItem.Prefab;
            var container = _offerWidgetHybridScrollObjectPoolItem.Container;
            var initCount = _offerWidgetHybridScrollObjectPoolItem.InitCount;
            OfferWidgetHybridScrollDragObjectPool = new OfferWidgetHybridScrollDragObjectPool(prefab, container, initCount);
        }
    }
}
