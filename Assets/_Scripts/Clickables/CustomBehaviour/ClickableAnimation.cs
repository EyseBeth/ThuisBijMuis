using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    [RequireComponent(typeof(Animator))]
    public class ClickableAnimation : MonoBehaviour, IClickable
    {
        private Animator animator;

        [HideInInspector] public UnityEvent OnAnimationEndedEvent;

        private void Start() => animator = GetComponent<Animator>();

        public void OnAnimationEnd()
        {
            animator.SetBool("OnSelect", false);

            OnAnimationEndedEvent?.Invoke();
        }

        public void ExecuteCustomBehaviour()
        {
            if (!animator.GetBool("OnSelect"))
                animator.SetBool("OnSelect", true);
        }
    }
}
