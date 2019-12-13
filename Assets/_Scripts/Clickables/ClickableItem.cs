using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using ThuisBijMuis.Games.Interactables.Indicators;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class ClickableItem : MonoBehaviour, IInteractable
    {
        private IClickable[] clickableCustomBehaviours;
        private ClickableIndicatorBase clickableIndicator;

        private void Start()
        {
            clickableCustomBehaviours = GetComponentsInChildren<IClickable>();
            clickableIndicator = GetComponent<ClickableIndicatorBase>();
        }

        // We just rewrite the list of references. This means it doesn't matter whether we add or remove.
        // In both cases the list will be completely rewritten which gives us an up to date list.
        public void UpdateCustomBehaviours() => clickableCustomBehaviours = GetComponentsInChildren<IClickable>();

        public void ActivateInteractable() {
            clickableIndicator?.Pause();
            foreach (IClickable item in clickableCustomBehaviours) {
                item.ExecuteCustomBehaviour();
            }
        }
    }
}
