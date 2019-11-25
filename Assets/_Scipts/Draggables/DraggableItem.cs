using UnityEngine;

namespace ThuisBijMuis.Draggables {
    [RequireComponent(typeof(Collider2D))]
    public class DraggableItem : MonoBehaviour, IDraggable {

        enum DragState {
            Null,
            Dragging,
            Dropped
        }

        Vector2 originalMousePosition;

        DragState state = DragState.Null;

        public void StartDrag() {
            state = DragState.Dragging;
            print("Started the drag");
        }

        public void Dragging() {
            print($"The current mouse position for dragging is {Input.mousePosition}");
        }

        public void EndDrag() {
            throw new System.NotImplementedException();
        }

        private Vector3 offset;
        float distanceToScreen = 10.0f;

        public void OnMouseDown() {

            offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen));
        }

        public void OnMouseDrag() {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }

        public void OnTouch() {

        }
    }
}
