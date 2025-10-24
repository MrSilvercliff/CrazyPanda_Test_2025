using UnityEngine;

namespace RedPanda.Project
{
    public interface IButtonAnimationConfig
    { 
        float ButtonContentScale { get; }
        float PointerDownScaleDuration { get; }
        float PointerUpScaleDuration { get; }
    }

    [CreateAssetMenu(fileName = "ButtonAnimationConfig", menuName = "Configs/DOTween/ButtonAnimationConfig")]
    public class ButtonAnimationConfig : ScriptableObject, IButtonAnimationConfig
    {
        public float ButtonContentScale => _buttonContentScale;
        public float PointerDownScaleDuration => _pointerDownScaleDuration;
        public float PointerUpScaleDuration => _pointerUpScaleDuration;

        [SerializeField] private float _buttonContentScale;
        [SerializeField] private float _pointerDownScaleDuration;
        [SerializeField] private float _pointerUpScaleDuration;
    }
}
