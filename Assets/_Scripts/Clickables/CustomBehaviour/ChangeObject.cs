using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangeObject : MonoBehaviour, IClickable
    {
        public GameObject[] firstSet;
        public GameObject[] secondSet;

        public bool objectsChanged = false;
        
        void Start()
        {
            //ensures the first set is active and the second is inactive on startup.
            ChangeThem(true, false);
        }

        public void ExecuteCustomBehaviour()
        {
            //Checks if the objects have already been switched, if it hasnt, it does so.
            if (objectsChanged == false)
            {
                objectsChanged = true;

                ChangeThem(false, true);
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
    }
}