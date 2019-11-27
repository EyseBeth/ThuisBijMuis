using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    public interface IDraggable {
        void OnMouseDown();
        void OnMouseDrag();
        void OnMouseUp();
        
    }
}
