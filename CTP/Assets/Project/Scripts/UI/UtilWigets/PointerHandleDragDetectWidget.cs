using UnityEngine;
using UnityEngine.EventSystems;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class PointerHandleDragDetectWidget : PointerHandleWidget
    {
        protected bool _isDragging;

        protected override void Awake()
        {
            base.Awake();
            _isDragging = false;
        }

        public virtual void OnBeginDrag()
        {
            _isDragging = true;
        }

        public void OnEndDrag()
        {
            _isDragging = false;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (_isDragging)
                return;

            base.OnPointerClick(eventData);
        }
    }
}
