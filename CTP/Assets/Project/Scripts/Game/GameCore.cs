using RedPanda.Project.Scripts.Configs;
using RedPanda.Project.Scripts.EventBus.Async;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.Services;
using RedPanda.Project.Scripts.Services.UnityAddressables;
using UnityEngine;

namespace RedPanda.Project.Scripts.Game
{
    public class GameCore : MonoBehaviour
    {
        public static GameCore Instance { get; private set; }

        public IDOTweenAnimationsConfig DOTweenAnimationsConfig => _doTweenAnimationsConfig;
        public IShopConfig ShopConfig => _shopConfig;

        public IUserModel User { get; private set; }
        public IEventBusAsync EventBus { get; private set; }
        public IShopService ShopService { get; private set; }
        public IAddressablesService AddressablesService { get; private set; }

        [SerializeField] private DOTweenAnimationsConfig _doTweenAnimationsConfig;
        [SerializeField] private ShopConfig _shopConfig;

        private void Awake()
        {
            Instance = this;

            User = new UserModel();
            EventBus = new EventBusAsync();
            ShopService = new ShopService();
            AddressablesService = new AddressablesService();
        }
    }
}
