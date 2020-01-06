using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specifically for filling the kites with their colour.
/// </summary>
namespace ThuisBijMuis.Games.Interactables.CustomBehaviours {
#pragma warning disable 0649, 0108
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeKite : ChangeObject, IClickable {
        VariableKeeper variableKeeper;

        void Start() {
            //ensures the first set is active and the second is inactive on startup.
            ChangeThem(true, false);
            variableKeeper = GameObject.Find("BookParent").GetComponent<VariableKeeper>();
        }

        public override void ExecuteCustomBehaviour() {
            if (!objectsChanged && variableKeeper.clrSelected) {
                objectsChanged = true;

                KiteSwitcher();
            }

        }

        private void KiteSwitcher() {
            if (variableKeeper.clrSelected) {
                foreach (GameObject obj in firstSet) obj.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (variableKeeper.blue) secondSet[0].GetComponent<SpriteRenderer>().enabled = true;
            else if (variableKeeper.red) secondSet[1].GetComponent<SpriteRenderer>().enabled = true;
            else if (variableKeeper.yellow) secondSet[2].GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
