using UnityEngine;

/// <summary>
/// Used for a drop zone that's meant to move after a draggable has been dropped on it.
/// </summary>
namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class MovingDropZone : DropZone
    {
        [SerializeField] private GameObject target;
        
        private float step = 0.1f;

        private void Update()
        {
            if (!IsDropped) return;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step*Time.deltaTime);
        }
    }
}
