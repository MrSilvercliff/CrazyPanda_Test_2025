using UnityEngine;

namespace RedPanda.Project
{
    public interface IMonoUpdatable
    {
        void OnUpdate(float deltaTime = 0);
    }
}
