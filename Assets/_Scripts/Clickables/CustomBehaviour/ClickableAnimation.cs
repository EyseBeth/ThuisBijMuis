using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    [RequireComponent(typeof(Animator))]
    public class ClickableAnimation : MonoBehaviour, IClickable
    {
        private Animator animator;

        [HideInInspector] public UnityEvent OnAnimationEndedEvent;

        private void Start()
        {
            animator = GetComponent<Animator>();
            animator.applyRootMotion = true;
        }

        // In animations you can add an animation event.
        // This method should be called by that event.
        public void OnAnimationEnd() => OnAnimationEndedEvent?.Invoke();

        public void ExecuteCustomBehaviour() => animator.SetTrigger("OnSelect");
    }
}
