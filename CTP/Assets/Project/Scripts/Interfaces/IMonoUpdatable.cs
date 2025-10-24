using UnityEngine;

namespace RedPanda.Project.Scripts.Interfaces
{
    public interface IMonoUpdatable
    {
        void OnUpdate(float deltaTime = 0);
    }
}
