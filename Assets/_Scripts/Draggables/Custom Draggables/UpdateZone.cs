using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public class UpdateZone : DropZone
    {
        public Sprite[] zoneReplace;
        public int counter = 0;
        // Update is called once per frame
        void Update()
        {
            if (IsDropped)
            {
                IsDropped = false;
                counter++;
                GetComponent<SpriteRenderer>().sprite = zoneReplace[counter];
            }
        }
    }
}
