using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Updates the tag on a draggable after i'ts been dropped in it's initial zone, makes it dissappear on second drop.
/// </summary>
namespace ThuisBijMuis.Games.Interactables
{
    public class UpdateDraggable : DraggableItem
    {
        [SerializeField] protected List<DroppableTags> updateTags;

        private bool filledUp = false;
        
        public override void Release()
        {
            if (currentDropZone != null && currentDropZone.CheckTags(ItemTags))
            {
                if (filledUp != true)
                {
                    filledUp = true;
                    Drop(currentDropZone);
                    ItemTags = updateTags;
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
