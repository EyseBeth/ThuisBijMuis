using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.Indicators {
#pragma warning disable 0649
    public abstract class ClickableIndicatorBase : MonoBehaviour
    {
        protected ClickableItem[] clickableItems;
        protected bool isPaused;

        protected virtual void Awake()
        {
            // Find all clickable items and store them in a variable.
            // Custom indicator scripts can then use this variable to 
            // add the indicator script to those items.
            clickableItems = FindObjectsOfType<ClickableItem>();
        }

        protected abstract void Init();

        public virtual void Pause()
        {
            isPaused = true;
            Init();
        }

        public virtual void UnPause() => isPaused = false;
    }
}