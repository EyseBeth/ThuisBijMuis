using UnityEngine;

namespace ThuisBijMuis.Games
{
#pragma warning disable 0649
    public class PageWipeTransition : MonoBehaviour
    {
        [SerializeField] private Animator transitionAnim;

        public void TransitionNext() => transitionAnim.SetTrigger("next");

        public void TransitionPrev() => transitionAnim.SetTrigger("prev");
    }
}