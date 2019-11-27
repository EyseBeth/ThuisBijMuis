using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649

    [RequireComponent(typeof(Collider2D))]
    public class DropZone : MonoBehaviour, IDroppable {

        [SerializeField] DroppableTags[] acceptableTags;

        public void Start() {
            Tags = new List<string>();
            foreach (DroppableTags tag in acceptableTags) {
                Tags.Add(tag.ToString());
            }
            CheckTags(new[] { DroppableTags.Jacket });
        }

        public void CheckTags(DroppableTags[] tags) {
            foreach (DroppableTags tag in tags) {
                if (!Tags.Contains(tags.ToString())) print("Uh Oh!");
            }
        }

        public List<string> Tags { get; private set; }
    }
}
