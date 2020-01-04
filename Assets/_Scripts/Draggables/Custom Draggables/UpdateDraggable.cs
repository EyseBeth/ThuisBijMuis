using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public class UpdateDraggable : DraggableItem
    {
        [SerializeField] protected List<DroppableTags> updateTags;
        private bool filledUp = false;
        public override void Release()
        {
            if (currentDropZone != null && currentDropZone.CheckTags(itemTags))
            {
                if (filledUp != true)
                {
                    filledUp = true;
                    Drop(currentDropZone);
                    itemTags = updateTags;
                }
                else
                {
                    Drop(currentDropZone);
                    GetComponent<SpriteRenderer>().enabled = false;
                    GetComponent<BoxCollider>().enabled = false;
                }
                
            }
            else Return();
            currentDropZone = null;
            selected = false;
        }
    }
}
