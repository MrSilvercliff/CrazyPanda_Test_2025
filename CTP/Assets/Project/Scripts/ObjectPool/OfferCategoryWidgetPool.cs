using RedPanda.Project.Scripts.UI.Widgets;
using UnityEngine;

namespace RedPanda.Project.Scripts.ObjectPool
{
    public interface IOfferCategoryWidgetPool : IMonoBehaviourPool<OfferCategoryWidget>
    { 
    }

    public class OfferCategoryWidgetPool : MonoBehaviourPool<OfferCategoryWidget>, IOfferCategoryWidgetPool
    {
        public OfferCategoryWidgetPool(OfferCategoryWidget source, Transform parent = null, int initCount = 0) : base(source, parent, initCount)
        {
        }

        public OfferCategoryWidgetPool(GameObject prefab, Transform parent = null, int initCount = 0) : base(prefab, parent, initCount)
        {
        }
    }
}
