using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649, 0108
    /// <summary>
    /// Specifically for filling the kites with their colour.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeKite : ChangeObject, IClickable
    {
        private VariableKeeper variableKeeper;

        private void Start()
        {
            // Ensures the first set is active and the second is inactive on startup.
            ChangeThem(true, false);
            variableKeeper = GameObject.Find("BookParent").GetComponent<VariableKeeper>();
        }

        public override void ExecuteCustomBehaviour()
        {
            if (!objectsChanged && variableKeeper.ClrSelected)
            {
                objectsChanged = true;
                KiteSwitcher();
            }
        }

        private void KiteSwitcher()
        {
            if (variableKeeper.ClrSelected)
                foreach (GameObject obj in firstSet) obj.GetComponent<SpriteRenderer>().enabled = false;

            if (variableKeeper.Blue) secondSet[0].GetComponent<SpriteRenderer>().enabled = true;
            else if (variableKeeper.Red) secondSet[1].GetComponent<SpriteRenderer>().enabled = true;
            else if (variableKeeper.Yellow) secondSet[2].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
