using UnityEngine;

namespace ThuisBijMuis.Clickables.Indicators
{
#pragma warning disable 0649
    public abstract class ClickableIndicatorBase : MonoBehaviour
    {
        protected ClickableItem[] clickableItems;
        protected bool isPaused;

        protected virtual void Awake()
        {
            // Find all clickable items and add the indicator to them.
            clickableItems = FindObjectsOfType<ClickableItem>();
        }

        protected abstract void Init();

        public virtual void Pause()
        {
            isPaused = true;
            Init();
        }

        public virtual void UnPause()
        {
            isPaused = false;
        }
    }
}