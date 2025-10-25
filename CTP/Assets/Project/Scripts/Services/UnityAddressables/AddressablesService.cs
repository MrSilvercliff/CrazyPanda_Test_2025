using UnityEngine;

namespace RedPanda.Project.Scripts.Services.UnityAddressables
{
    public interface IAddressablesService
    { 
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
    }
}
