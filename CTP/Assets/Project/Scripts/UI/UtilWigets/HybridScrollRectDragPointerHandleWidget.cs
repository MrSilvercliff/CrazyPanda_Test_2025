using System;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class HybridScrollRectDragPointerHandleWidget : MonoBehaviour
    {
        [SerializeField] private HybridScrollRectDragWidget _hybridScrollRectDragWidget;
        [SerializeField] private PointerHandleDragDetectWidget _pointerHandleDragDetectWidget;

        private void OnEnable()
        {
            _hybridScrollRectDragWidget.OnBeginDragEvent += OnBeginDragEvent;
            _hybridScrollRectDragWidget.OnEndDragEvent += OnEndDragEvent;
        }

        private void OnDisable()
        {
            _hybridScrollRectDragWidget.OnBeginDragEvent -= OnBeginDragEvent;
            _hybridScrollRectDragWidget.OnEndDragEvent -= OnEndDragEvent;
        }

        public void Setup(ScrollRect verticalScrollRect, ScrollRect horizontalScrollRect)
        { 
            _hybridScrollRectDragWidget.Setup(verticalScrollRect, horizontalScrollRect);
        }

        private void OnBeginDragEvent()
        {
            _pointerHandleDragDetectWidget.OnBeginDrag();
        }

        private void OnEndDragEvent()
        {
            _pointerHandleDragDetectWidget.OnEndDrag();
        }
    }
}
