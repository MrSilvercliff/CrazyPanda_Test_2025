using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class PointerHandleWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private Button _button;

        private bool _pointerDownHandled;
        private bool _pointerEntered;
        private bool _canInvokeClick;

        protected virtual void Awake()
        {
            _pointerDownHandled = false;
            _pointerEntered = false;
            _canInvokeClick = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEntered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _pointerEntered = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pointerDownHandled = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_pointerEntered && _pointerDownHandled)
                _canInvokeClick = true;

            _pointerDownHandled = false;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!_canInvokeClick)
                return;

            Debug.LogError($"POINTER CLICK INVOKE");
            _canInvokeClick = false;
            _button.onClick?.Invoke();
        }
    }
}
