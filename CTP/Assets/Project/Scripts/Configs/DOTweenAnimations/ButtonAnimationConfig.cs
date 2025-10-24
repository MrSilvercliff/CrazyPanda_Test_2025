using UnityEngine;

namespace RedPanda.Project
{
    public interface IButtonAnimationConfig
    { 
        float ContentScaleValue { get; }
        float ScaleDownDuration { get; }
        float ScaleUpDuration { get; }
    }

    [CreateAssetMenu(fileName = "ButtonAnimationConfig", menuName = "Configs/DOTween/ButtonAnimationConfig")]
    public class ButtonAnimationConfig : ScriptableObject, IButtonAnimationConfig
    {
        public float ContentScaleValue => _buttonContentScale;
        public float ScaleDownDuration => _pointerDownScaleDuration;
        public float ScaleUpDuration => _pointerUpScaleDuration;

        [SerializeField] private float _buttonContentScale;
        [SerializeField] private float _pointerDownScaleDuration;
        [SerializeField] private float _pointerUpScaleDuration;
    }
}
