using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using ThuisBijMuis.Games.Interactables.Indicators;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class ClickableItem : MonoBehaviour
    {
        private IClickable[] clickableCustomBehaviours;
        private ClickableIndicatorBase clickableIndicator;

        private void Start()
        {
            clickableCustomBehaviours = GetComponentsInChildren<IClickable>();
            clickableIndicator = GetComponent<ClickableIndicatorBase>();
        }

        public void UpdateIClickables()
        {
            clickableCustomBehaviours = GetComponentsInChildren<IClickable>();
        }

        // OnMouseDown also works with touch as long as Input.simulateMouseWithTouch is enabled.
        private void OnMouseDown()
        {
            clickableIndicator?.Pause();
            foreach (IClickable item in clickableCustomBehaviours)
            {
                item.ExecuteCustomBehaviour();
            }
        }
    }
}
