using RedPanda.Project.Scripts.UI.Widgets;
using UnityEngine;

namespace RedPanda.Project.Scripts.ObjectPool
{
    public interface IOfferWidgetHybridScrollDragObjectPool : IMonoBehaviourPool<OfferWidgetHybridScrollDrag>
    { 
    }

    public class OfferWidgetHybridScrollDragObjectPool : MonoBehaviourPool<OfferWidgetHybridScrollDrag>, IOfferWidgetHybridScrollDragObjectPool
    {
        public OfferWidgetHybridScrollDragObjectPool(OfferWidgetHybridScrollDrag source, Transform parent = null, int initCount = 0) : base(source, parent, initCount)
        {
        }

        public OfferWidgetHybridScrollDragObjectPool(GameObject prefab, Transform parent = null, int initCount = 0) : base(prefab, parent, initCount)
        {
        }
    }
}
