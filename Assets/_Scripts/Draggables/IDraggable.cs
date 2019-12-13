using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public interface IDraggable {
        void OnMouseDrag();
        void OnMouseUp();
        void Return();
        void Drop(DropZone drop);

    }
}
