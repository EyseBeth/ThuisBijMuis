using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageWipeTransition : MonoBehaviour
{
    public Animator transitionAnim;

    public void TransitionNext() => transitionAnim.SetTrigger("next");

    public void TransitionPrev() => transitionAnim.SetTrigger("prev");
}
