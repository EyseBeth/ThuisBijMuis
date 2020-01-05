using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specifically for page 9, checks if there's been an ONTrigger enter before enabling sprite change on click.
/// </summary>
namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class ChangeFlower : ChangeObject, IClickable
    {
        public bool isWatered = false;
        public override void ExecuteCustomBehaviour()
        {
            //Checks if the objects have already been switched, if it hasnt, it does so.
            if (objectsChanged == false && isWatered)
            {
                objectsChanged = true;

                ChangeThem(false, true);
            }
        }

        public void OnTriggerEnter()
        {
            isWatered = true;
        }
    }
}
