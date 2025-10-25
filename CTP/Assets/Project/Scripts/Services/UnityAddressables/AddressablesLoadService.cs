using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace RedPanda.Project.Scripts.Services.UnityAddressables
{
    public interface IAddressablesLoadService
    {
        Task<T> LoadAsync<T>(AssetReference assetReference);
    }

    public class AddressablesLoadService : IAddressablesLoadService
    {
        private IAddressablesRepository _repository;

        public AddressablesLoadService(IAddressablesRepository repository) 
        { 
            _repository = repository;
        }

        public async Task<T> LoadAsync<T>(AssetReference assetReference)
        {
            var asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetReference);

            await asyncOperationHandle.Task;

            if (asyncOperationHandle.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogError($"ASYNC OPERATION FAILED!");
                Debug.LogError($"Status = {asyncOperationHandle.Status}");
                Debug.LogError($"OperationException.Message = {asyncOperationHandle.OperationException.Message}");
                Debug.LogError($"OperationException.StackTrace = {asyncOperationHandle.OperationException.StackTrace}");
                return default(T);
            }

            var result = asyncOperationHandle.Result;
            return result;
        }
    }
}
