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

        // In animations you can add an animation event.
        // This method should be called by that event.
        public void OnAnimationEnd()
        {
            animator.SetBool("OnSelect", false);
            OnAnimationEndedEvent?.Invoke();
        }

        public void ExecuteCustomBehaviour() => animator.SetBool("OnSelect", true);
    }
}
