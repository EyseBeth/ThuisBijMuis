using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeKite : ChangeObject, IClickable
    {
        VariableKeeper variableKeeper;

        void Start()
        {
            //ensures the first set is active and the second is inactive on startup.
            ChangeThem(true, false);
            variableKeeper = GameObject.Find("BookParent").GetComponent<VariableKeeper>();
        }

        public void ExecuteCustomBehaviour()
        {
            if (objectsChanged == false && variableKeeper.clrSelected == true)
            {
                objectsChanged = true;

                KiteSwitcher();
            }
            
        }

        private void ChangeThem(bool forFirst, bool forSec)
        {
            foreach (GameObject obj in firstSet)
            {
                obj.GetComponent<SpriteRenderer>().enabled = forFirst;
            }

            foreach (GameObject obj in secondSet)
            {
                obj.GetComponent<SpriteRenderer>().enabled = forSec;
            }
        }

        private void KiteSwitcher()
        {
            if (variableKeeper.clrSelected == true)
            {
                foreach (GameObject obj in firstSet)
                {
                    obj.GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            
            if (variableKeeper.blue == true)
            {
                secondSet[0].GetComponent<SpriteRenderer>().enabled = true;
            }
            if (variableKeeper.red == true)
            {
                secondSet[1].GetComponent<SpriteRenderer>().enabled = true;
            }
            if (variableKeeper.yellow == true)
            {
                secondSet[2].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}
