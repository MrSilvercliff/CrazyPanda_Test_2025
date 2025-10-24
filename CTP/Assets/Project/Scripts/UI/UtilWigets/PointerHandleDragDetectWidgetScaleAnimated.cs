using _Project.Scripts.Application.Project.Helpers;
using DG.Tweening;
using RedPanda.Project.Scripts.Game;
using RedPanda.Project.Scripts.UI.UtilWigets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RedPanda.Project
{
    public class PointerHandleDragDetectWidgetScaleAnimated : PointerHandleDragDetectWidget
    {
        [SerializeField] private Transform _contentToScale;

        private Sequence _currentSequence;

        protected override void Awake()
        {
            base.Awake();
            _currentSequence = null;
        }

        public override void OnBeginDrag()
        {
            PlayScaleUpSequence();
            base.OnBeginDrag();
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);

            if (_pointerDownHandled)
                PlayScaleDownSequence();
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            base.OnPointerExit(eventData);
            PlayScaleUpSequence();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            if (_pointerEntered)
                PlayScaleDownSequence();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            PlayScaleUpSequence();
            base.OnPointerUp(eventData);
        }

        private void PlayScaleDownSequence()
        {
            if (_isDragging)
                return;

            DOTweenHelper.KillSequence(_currentSequence);
            PrepareScaleDownSequence();
            _currentSequence.Play();
        }

        private void PlayScaleUpSequence()
        {
            if (_isDragging)
                return;

            DOTweenHelper.KillSequence(_currentSequence);
            PrepareScaleUpSequence();
            _currentSequence.Play();
        }

        private void PrepareScaleDownSequence()
        {
            var config = GameController.Instance.DOTweenAnimationsConfig.ButtonAnimationConfig;

            var scaleValue = config.ContentScaleValue;
            var duration = config.ScaleDownDuration;

            _currentSequence = DOTween.Sequence();
            _currentSequence.Append(_contentToScale.DOScale(scaleValue, duration));
        }

        private void PrepareScaleUpSequence()
        {
            var config = GameController.Instance.DOTweenAnimationsConfig.ButtonAnimationConfig;

            var scaleValue = 1f;
            var duration = config.ScaleUpDuration;

            _currentSequence = DOTween.Sequence();
            _currentSequence.Append(_contentToScale.DOScale(scaleValue, duration));
        }
    }
}
