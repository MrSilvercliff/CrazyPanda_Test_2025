using UnityEngine;

namespace RedPanda.Project.Scripts.ObjectPool
{
    public interface IPoolable
    {
        void OnCreate();
        void OnSpawn();
        void OnDespawn();
    }
}
