using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class DraggableItem : MonoBehaviour, IDraggable, IInteractable {

        [SerializeField] private DroppableTags[] acceptableTags;

        const float DistanceToScreen = 10.0f;

        private Vector2 originalMousePosition;
        private Vector3 offset, originalPosition;

        private DropZone currentDropZone;

        void Start() {
            transform.position = originalPosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z - Mathf.Epsilon);
        }

        public void OnMouseDrag() {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceToScreen);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }

        public void OnMouseUp() {
            if (currentDropZone != null && currentDropZone.CheckTags(acceptableTags)) {
                Drop(currentDropZone);
            } else Return();
            currentDropZone = null;
        }

        public void Return() {
            gameObject.transform.position = originalPosition;
        }

        public void Drop(DropZone drop) {
            gameObject.transform.position = new Vector3(drop.transform.position.x, drop.transform.position.y, drop.transform.position.z - Mathf.Epsilon);
        }
        private void OnTriggerStay(Collider collision) {
            currentDropZone = collision.transform.GetComponent<DropZone>();

        }
        private void OnTriggerExit(Collider collision) {
            currentDropZone = null;
        }

        public void ActivateInteractable() {
            offset = gameObject.transform.position -
                     Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceToScreen));
        }
    }
}
