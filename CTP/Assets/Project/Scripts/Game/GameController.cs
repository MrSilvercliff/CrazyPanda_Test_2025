using RedPanda.Project.Scripts.Configs;
using RedPanda.Project.Scripts.EventBus.Async;
using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.Services;
using RedPanda.Project.Scripts.Services.UnityAddressables;
using RedPanda.Project.Scripts.UI;
using System.Threading.Tasks;
using UnityEngine;

namespace RedPanda.Project.Scripts.Game
{
    public class GameController : MonoBehaviour
    {
        private IUserModel _userModel;
        private IAddressablesConfig _addressablesConfig;
        private IAddressablesService _addressablesService;

        private void Awake()
        {
        }

        private async void Start()
        {
            _userModel = GameCore.Instance.User;
            _addressablesConfig = GameCore.Instance.AddressablesConfig;
            _addressablesService = GameCore.Instance.AddressablesService;

            var shopView = await _addressablesService.LoadShopViewAsync(_addressablesConfig.ShopView);
            var instance = Instantiate(shopView);
            instance.Init();
            instance.gameObject.SetActive(true);
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _userModel.OnUpdate(deltaTime);
        }
    }
}
