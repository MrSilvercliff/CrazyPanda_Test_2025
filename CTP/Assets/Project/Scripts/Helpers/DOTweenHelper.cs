using DG.Tweening;

namespace _Project.Scripts.Application.Project.Helpers
{
    public static class DOTweenHelper
    {
        public static void KillSequence(Sequence sequence, bool complete = false)
        {
            if (sequence == null)
                return;

            if (!sequence.IsActive())
                return;

            if (!sequence.IsPlaying())
                return;

            sequence.Kill(complete);
        }
    }
}