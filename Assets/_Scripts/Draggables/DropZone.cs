using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649

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

        public bool IsDropped { get; set; }
    }
}
