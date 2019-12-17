using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    //IDraggable adds the required functions that each and every draggable item requires
    public interface IDraggable {
        void Drag();
        void Release();
        void Return();
        void Drop(DropZone drop);

    }
}
