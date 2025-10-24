using UnityEngine;

namespace RedPanda.Project
{
    public class Game : MonoBehaviour
    {
        public static UserModel User { get; private set; }
        public static ShopModel Shop { get; private set; }
        public static IShopService ShopService { get; private set; }

        [SerializeField] private ShopView _shopView;

        private void Awake()
        {
            User = new UserModel();
            Shop = new ShopModel();
            ShopService = new ShopService();
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
