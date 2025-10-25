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
        [SerializeField] private ShopView _shopView;

        private IUserModel _userModel;

        private void Awake()
        {
        }

        private void Start()
        {
            _userModel = GameCore.Instance.User;

            _shopView.Init();
            _shopView.gameObject.SetActive(true);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _userModel.OnUpdate(deltaTime);
        }
    }
}
