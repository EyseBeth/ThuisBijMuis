using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649

<<<<<<< HEAD
    [RequireComponent(typeof(BoxCollider))]
    public class DropZone : MonoBehaviour, IDroppable {

        //The Tags property List is used to check the tags of the draggable item.
        //The tags private list is used instead of an auto property due to serializing in the Unity Editor
        public List<DroppableTags> Tags { get => tags; private set => tags = value; }
        [SerializeField] private List<DroppableTags> tags;

        //CheckTags checks a list of tags given by the draggable against the list of tags given at creation for an (un)acceptable drop position
        public bool CheckTags(List<DroppableTags> tags) {
            return tags.All(t => Tags.Contains(t));
        }

=======
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
>>>>>>> 6d99c0c49bd1205e25aa68a358c803b940c16b17
    }
}
