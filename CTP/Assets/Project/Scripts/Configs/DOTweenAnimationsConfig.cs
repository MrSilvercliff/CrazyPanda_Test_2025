using UnityEngine;

namespace RedPanda.Project.Scripts.Configs
{
    public interface IDOTweenAnimationsConfig
    { 
        IButtonAnimationConfig ButtonAnimationConfig { get; }
    }

    [CreateAssetMenu(fileName = "DOTweenAnimationsConfig", menuName = "Configs/DOTween/DOTween Animations Config")]
    public class DOTweenAnimationsConfig : ScriptableObject, IDOTweenAnimationsConfig
    {
        public IButtonAnimationConfig ButtonAnimationConfig => _buttonAnimationConfig;

        [SerializeField] private ButtonAnimationConfig _buttonAnimationConfig;
    }
}
