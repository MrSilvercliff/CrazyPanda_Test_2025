using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace RedPanda.Project.Scripts.Services.UnityAddressables
{
    public interface IAddressablesRepository
    {
        IReadOnlyCollection<AsyncOperationHandle> GetAll();

        bool TryGet(string guid, out AsyncOperationHandle asyncOperationHandle);
        void Add(string guid, AsyncOperationHandle asyncOperationHandle);
        void Remove(string guid);
    }

    public class AddressablesRepository : IAddressablesRepository
    {
        private Dictionary<string, AsyncOperationHandle> _operationHandleByGUID;

        public AddressablesRepository()
        {
            _operationHandleByGUID = new();
        }

        public IReadOnlyCollection<AsyncOperationHandle> GetAll()
        {
            var result = _operationHandleByGUID.Values;
            return result;
        }

        public bool TryGet(string guid, out AsyncOperationHandle asyncOperationHandle)
        {
            var result = _operationHandleByGUID.TryGetValue(guid, out asyncOperationHandle);
            return result;
        }

        public void Add(string guid, AsyncOperationHandle asyncOperationHandle)
        {
            _operationHandleByGUID[guid] = asyncOperationHandle;
        }

        public void Remove(string guid)
        {
            _operationHandleByGUID.Remove(guid);
        }
    }
}
