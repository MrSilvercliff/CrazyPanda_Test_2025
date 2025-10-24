using UnityEngine;
using UnityEngine.EventSystems;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class PointerHandleDragDetectWidget : PointerHandleWidget
    {
        private bool _isDragging;

        protected override void Awake()
        {
            base.Awake();
            _isDragging = false;
        }

        public void OnBeginDrag()
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
