using RedPanda.Project.Scripts.EventBus.Async;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.Services;
using RedPanda.Project.Scripts.UI;
using UnityEngine;

namespace RedPanda.Project.Scripts.Game
{
    public class GameController : MonoBehaviour
    {
        public static UserModel User { get; private set; }
        public static ShopModel Shop { get; private set; }
        public static IShopService ShopService { get; private set; }
        public static IEventBusAsync EventBus { get; private set; }

        [SerializeField] private ShopView _shopView;

        private void Awake()
        {
            User = new UserModel();
            Shop = new ShopModel();
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
