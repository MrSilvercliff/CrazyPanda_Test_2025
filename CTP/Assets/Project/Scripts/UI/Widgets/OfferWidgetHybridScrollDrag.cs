using RedPanda.Project.Scripts.Model;
using RedPanda.Project.Scripts.ObjectPool;
using RedPanda.Project.Scripts.UI.UtilWigets;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.Widgets
{
    public class OfferWidgetHybridScrollDrag : MonoBehaviour, IPoolable
    {
        [SerializeField] private OfferWidget _offerWidget;
        [SerializeField] private HybridScrollRectDragPointerHandleWidget _hybridScrollRect;

        public void Setup(OfferModel offerModel)
        {
            _offerWidget.Setup(offerModel);
        }

        public void Setup(ScrollRect verticalScrollRect, ScrollRect horizontalScrollRect)
        {
            _hybridScrollRect.Setup(verticalScrollRect, horizontalScrollRect);
        }

        public void OnCreate()
        {
        }

        public void OnSpawn()
        {
        }

        public void OnDespawn()
        {
        }
    }
}
