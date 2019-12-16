using UnityEngine;
using UnityEngine.EventSystems;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class DraggableItem : MonoBehaviour, IDraggable, IInteractable {

        [SerializeField] private DroppableTags[] itemTags;
        [SerializeField] private RectTransform canvasRectTransform;

        public static float DistanceToScreen { get; } = 10.0f;

        private Vector2 originalMousePosition;
        private Vector3 offset, originalPosition;

        private DropZone currentDropZone;

        void Start() {
            originalPosition = transform.localPosition;
        }

        public void OnMouseDrag() {
            print(currentDropZone);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos);
            transform.position = canvasRectTransform.TransformPoint(pos) + offset;
        }

        public void OnMouseUp() {
            if (currentDropZone != null && currentDropZone.CheckTags(itemTags)) {
                Drop(currentDropZone);
            } else Return();
            currentDropZone = null;
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
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos)) {
                offset = (Vector2)transform.position - (Vector2)canvasRectTransform.TransformPoint(pos);
            }
        }
    }
}
