using UnityEngine;

namespace RedPanda.Project
{
    public class Game : MonoBehaviour
    {
        public static UserModel User { get; private set; } = new UserModel();
        public static ShopModel Shop { get; private set; } = new ShopModel();

        private void Awake()
        {
            User = new UserModel();
            Shop = new ShopModel();
        }

        private void Start()
        {
            Debug.LogWarning("Show ShopView from here");
        }

        private void Update()
        {
            User.Update();
        }
    }
}
