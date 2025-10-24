using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RedPanda.Project.Scripts.UI.UtilWigets
{
    public class PointerHandleWidget : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField] private Button _button;

        protected bool _pointerDownHandled;
        protected bool _pointerEntered;
        protected bool _canInvokeClick;

        protected virtual void Awake()
        {
            _pointerDownHandled = false;
            _pointerEntered = false;
            _canInvokeClick = false;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            _pointerEntered = true;
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            _pointerEntered = false;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {
            _pointerDownHandled = true;
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            if (_pointerEntered && _pointerDownHandled)
                _canInvokeClick = true;

            _pointerDownHandled = false;
        }

        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (!_canInvokeClick)
                return;

            if (!_button.interactable)
                return;

            _canInvokeClick = false;
            _button.onClick?.Invoke();
        }
    }
}
