using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public class VanishDraggable : DraggableItem
    {
        public override void Release()
        {
            if (currentDropZone != null && currentDropZone.CheckTags(itemTags))
            {
                Drop(currentDropZone);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
            else Return();
            currentDropZone = null;
            selected = false;
        }
    }
}
