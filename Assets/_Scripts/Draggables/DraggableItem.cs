using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    [RequireComponent(typeof(Collider2D))]
    public class DraggableItem : MonoBehaviour, IDraggable {

        [SerializeField] private DroppableTags[] acceptableTags;

        private Vector2 originalMousePosition;

        //public void StartDrag() {
        //    state = DragState.Dragging;
        //    print("Started the drag");
        //}

        private Vector3 offset, originalPosition;
        private float distanceToScreen = 10.0f;

        public void OnMouseDown() {
            print("Started the drag");
            originalPosition = gameObject.transform.position;
            offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
        }

        public void OnMouseDrag() {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }

        public void OnMouseUp() {
            gameObject.transform.position = originalPosition;
        }
    }
}
