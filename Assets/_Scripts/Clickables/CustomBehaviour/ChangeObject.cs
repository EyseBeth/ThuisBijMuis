using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    /// <summary>
    /// Changes the sprite on a clickable after it has been clicked.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeObject : MonoBehaviour, IClickable
    {
        [SerializeField] protected GameObject[] firstSet;
        [SerializeField] protected GameObject[] secondSet;

        protected bool objectsChanged;

        // Ensures the first set is active and the second is inactive on startup.
        private void Start() => ChangeThem(true, false);

        public virtual void ExecuteCustomBehaviour()
        {
            // Checks if the objects have already been switched, if it hasn't, it does so.
            if (objectsChanged == false)
            {
                objectsChanged = true;
                ChangeThem(false, true);
            }
        }

        protected void ChangeThem(bool forFirst, bool forSec)
        {
            foreach (GameObject obj in firstSet) obj.GetComponent<SpriteRenderer>().enabled = forFirst;
            foreach (GameObject obj in secondSet) obj.GetComponent<SpriteRenderer>().enabled = forSec;
        }
    }
}