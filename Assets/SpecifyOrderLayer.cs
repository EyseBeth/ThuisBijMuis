using ThuisBijMuis.Games.Interactables;
using UnityEngine;

namespace ThuisBijMuis.Games {
    public class SpecifyOrderLayer : MonoBehaviour {
        //Sets the sorting order of all sprites to 1 to avoid visual glitches and sets draggables to 2 to prevent clipping with the drop zones
        void Awake() {
            SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer s in sprites) {
                s.sortingOrder = s.GetComponent<DraggableItem>() ? 5 : s.sortingOrder > 1 ? s.sortingOrder : 1;
            }
        }
    }
}
