using RedPanda.Project.Scripts.Configs;
using RedPanda.Project.Scripts.EventBus.Async;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.Services;
using RedPanda.Project.Scripts.UI;
using UnityEngine;

namespace RedPanda.Project.Scripts.Game
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public IDOTweenAnimationsConfig DOTweenAnimationsConfig => _doTweenAnimationsConfig;
        public IShopConfig ShopConfig => _shopConfig;

        public IUserModel User { get; private set; }
        public IShopService ShopService { get; private set; }
        public IEventBusAsync EventBus { get; private set; }

        [SerializeField] private DOTweenAnimationsConfig _doTweenAnimationsConfig;
        [SerializeField] private ShopConfig _shopConfig;
        [SerializeField] private ShopView _shopView;

        private void Awake()
        {
            Instance = this;

            User = new UserModel();
            ShopService = new ShopService();
            EventBus = new EventBusAsync();
        }

        private void Start()
        {
            _shopView.Init();
            _shopView.gameObject.SetActive(true);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            User.OnUpdate(deltaTime);
        }
    }
}
