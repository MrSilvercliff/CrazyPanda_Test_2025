using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class HybridScrollRectDragWidget : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public event Action OnBeginDragEvent;
        public event Action OnEndDragEvent;

        [SerializeField] private ScrollRect _horizontalScrollRect;
        [SerializeField] private ScrollRect _verticalScrollRect;
        [SerializeField] private float _dragDeltaThreshold;

        private bool _horizontalDragging;
        private bool _verticalDragging;

        public void OnPointerDown(PointerEventData eventData)
        {
            _horizontalDragging = false;
            _verticalDragging = false;

            _horizontalScrollRect.StopMovement();
            _verticalScrollRect.StopMovement();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _horizontalScrollRect.OnBeginDrag(eventData);
            _verticalScrollRect.OnBeginDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            var deltaX = Mathf.Abs(eventData.delta.x);
            var deltaY = Mathf.Abs(eventData.delta.y);

            if (!_horizontalDragging && deltaX > _dragDeltaThreshold && deltaX > deltaY && !_verticalDragging)
            {
                _horizontalDragging = true;
                OnBeginDragEvent?.Invoke();
            }

            if (!_verticalDragging && deltaY > _dragDeltaThreshold && deltaY > deltaX && !_horizontalDragging)
            {
                _verticalDragging = true;
                OnBeginDragEvent?.Invoke();
            }

            if (_horizontalDragging)
                _horizontalScrollRect.OnDrag(eventData);

            if (_verticalDragging)
                _verticalScrollRect.OnDrag(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _horizontalScrollRect.OnEndDrag(eventData);
            _verticalScrollRect.OnEndDrag(eventData);

            _horizontalDragging = false;
            _verticalDragging = false;

            OnEndDragEvent?.Invoke();
        }
    }
}
