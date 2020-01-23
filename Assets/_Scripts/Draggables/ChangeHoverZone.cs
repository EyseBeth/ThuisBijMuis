using System.Collections.Generic;
using System.Linq;
using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    public class ChangeHoverZone : MonoBehaviour, IHoverable
    {
        [SerializeField] private List<DroppableTags> tags;

        private bool isActivated = false;

        public List<DroppableTags> Tags
        {
            get => tags;
            private set => tags = value;
        }

        public void ActivateHover(List<DroppableTags> tags)
        {
            if (isActivated || !tags.All(t => Tags.Contains(t))) return;
            foreach (IClickable c in GetComponents<IClickable>()) c.ExecuteCustomBehaviour();

            if (GetComponent<ClickableAudio>()) Destroy(GetComponent<ClickableAudio>());
        }
    }
}
