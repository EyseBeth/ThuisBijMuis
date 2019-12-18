using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649

    [RequireComponent(typeof(Collider))]
    public class DropZone : MonoBehaviour, IDroppable
    {
        [SerializeField] DroppableTags[] acceptableTags;

        public void Start()
        {
            //gameObject.layer = 2;
            Tags = new List<string>();
            foreach (DroppableTags tag in acceptableTags)
            {
                Tags.Add(tag.ToString());
            }
            CheckTags(new[] { DroppableTags.Jacket });
        }

        public bool CheckTags(DroppableTags[] tags)
        {
            return !tags.All(tag => Tags.Contains(tags.ToString()));
        }

        public List<string> Tags { get; private set; }
        public bool IsDropped { get; set; }
    }
}
