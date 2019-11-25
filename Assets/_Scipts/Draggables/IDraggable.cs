using UnityEngine;

namespace ThuisBijMuis.Draggables {
    public interface IDraggable {

        void StartDrag();
        void Dragging();
        void EndDrag();
        void OnMouseDown();

    }
}
