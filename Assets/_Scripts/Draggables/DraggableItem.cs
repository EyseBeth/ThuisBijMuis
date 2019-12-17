using UnityEngine;
using UnityEngine.EventSystems;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class DraggableItem : MonoBehaviour, IDraggable, IInteractable {

        [SerializeField] private DroppableTags[] itemTags;
        [SerializeField] private RectTransform canvasRectTransform;

        private bool selected = false;
        private Vector3 originalPosition;
        private DropZone currentDropZone;

        private void Start() {
            originalPosition = transform.localPosition;
        }

        public void OnMouseDrag() {
            if (!selected) return;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos);
            transform.position = canvasRectTransform.TransformPoint(pos);
        }

        public void OnMouseUp() {
            if (currentDropZone != null && currentDropZone.CheckTags(itemTags)) {
                Drop(currentDropZone);
            } else Return();
            currentDropZone = null;
            selected = false;
        }

        public void Return() {
            transform.localPosition = originalPosition;
        }

        public void Drop(DropZone drop) {
            transform.localPosition = new Vector3(drop.transform.localPosition.x, drop.transform.localPosition.y, drop.transform.localPosition.z - 0.000001f);
        }
        private void OnTriggerStay(Collider collision) {
            currentDropZone = collision.transform.GetComponent<DropZone>();

        }
        private void OnTriggerExit(Collider collision) {
            currentDropZone = null;
        }

        public void ActivateInteractable() {
            print(true);
            selected = true;
        }
    }
}
