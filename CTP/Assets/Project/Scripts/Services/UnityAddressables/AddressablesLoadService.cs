using UnityEngine;

namespace RedPanda.Project.Scripts.Services.UnityAddressables
{
    public interface IAddressablesLoadService
    { 
    }

    public class AddressablesLoadService : IAddressablesLoadService
    {
        public AddressablesLoadService(IAddressablesRepository repository) 
        { 
        }
    }
}
