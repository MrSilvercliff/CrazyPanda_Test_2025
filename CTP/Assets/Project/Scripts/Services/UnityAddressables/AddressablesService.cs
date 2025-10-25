using RedPanda.Project.Scripts.UI;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace RedPanda.Project.Scripts.Services.UnityAddressables
{
    public interface IAddressablesService
    { 
        Task<ShopView> LoadShopViewAsync(AssetReferenceGameObject assetReference);
        Task<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference);
        Task<Sprite> LoadSpriteAsync(AssetReference assetReference, Action<Sprite> loadCallback);
    }

    public class AddressablesService : IAddressablesService
    {
        private IAddressablesRepository _repository;
        private IAddressablesLoadService _loadService;

        public AddressablesService() 
        { 
            _repository = new AddressablesRepository();
            _loadService = new AddressablesLoadService(_repository);
        }

        public async Task<ShopView> LoadShopViewAsync(AssetReferenceGameObject assetReference)
        {
            var shopViewGameObject = await LoadAsync<GameObject>(assetReference);
            var result = shopViewGameObject.GetComponent<ShopView>();
            return result;
        }

        public async Task<GameObject> LoadGameObjectAsync(AssetReferenceGameObject assetReference)
        {
            var result = await LoadAsync<GameObject>(assetReference);
            return result;
        }

        public async Task<Sprite> LoadSpriteAsync(AssetReference assetReference, Action<Sprite> loadCallback)
        {
            var result = await LoadAsync<Sprite>(assetReference);
            loadCallback.Invoke(result);
            return result;
        }

        private async Task<T> LoadAsync<T>(AssetReference assetReference)
        {
            var guid = assetReference.AssetGUID;
            var tryResult = _repository.TryGet(guid, out var asyncOperationHandle);

            T result = default(T);

            if (tryResult)
            {
                if (!asyncOperationHandle.IsDone)
                    await asyncOperationHandle.Task;

                result = (T)asyncOperationHandle.Result;
                return result;
            }

            result = await _loadService.LoadAsync<T>(assetReference);
            return result;
        }
    }
}
