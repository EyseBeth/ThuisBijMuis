using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used for a drop zone that's meant to move after a draggable has been dropped on it.
/// </summary>
namespace ThuisBijMuis.Games.Interactables
{
    public class MovingDropZone : DropZone
    {
        public GameObject target;
        private float step = 0.1f;

        void Update()
        {
            if (!IsDropped) 
                return;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step*Time.deltaTime);
            
        }
    }
}
