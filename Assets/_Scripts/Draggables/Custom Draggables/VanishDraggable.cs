using UnityEngine;

/// <summary>
/// Makes draggable dissappear after it's beenn dropped on its respective drop zone.
/// </summary>
namespace ThuisBijMuis.Games.Interactables
{
    public class VanishDraggable : DraggableItem
    {
        public override void Release()
        {
            if (currentDropZone != null && currentDropZone.CheckTags(ItemTags))
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
