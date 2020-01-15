using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public class RemoveHoverZone : MonoBehaviour, IHoverable {
        private bool isActivated = false;

        public void ActivateHover(List<DroppableTags> tags) {
            if (isActivated || !tags.All(t => Tags.Contains(t))) return;
            foreach (IClickable c in GetComponents<IClickable>()) {
                c.ExecuteCustomBehaviour();
            }

            //isActivated = true;

        }

        public List<DroppableTags> Tags {
            get => tags;
            private set => tags = value;
        }

        [SerializeField] private List<DroppableTags> tags;
    }
}
