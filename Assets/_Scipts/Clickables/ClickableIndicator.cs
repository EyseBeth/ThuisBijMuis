using UnityEngine;

namespace ThuisBijMuis.Clickables
{
#pragma warning disable 0649
    public class ClickableIndicator : MonoBehaviour
    {
        [SerializeField] private ClickableIndicatorEnum.IndicatorType clickableIndicatorType;

        private void Awake()
        {
            // Find all clickable items and add the indicator to them.
            ClickableItem[] clickableItems = FindObjectsOfType<ClickableItem>();
            for (int i = 0; i < clickableItems.Length; i++)
            {
                GameObject obj = clickableItems[i].gameObject;

                switch (clickableIndicatorType)
                {
                    case ClickableIndicatorEnum.IndicatorType.Outline:
                        // Add outline component.
                        break;
                }
            }
        }
    }
}