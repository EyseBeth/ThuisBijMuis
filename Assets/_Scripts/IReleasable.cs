using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    //The IReleasable is an IInteractable that also has a release function, which is called on mouse/touch up
    public interface IReleasable : IInteractable {
        void ReleaseInteractable();
    }
}
