using UnityEngine;
using UnityEngine.EventSystems;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class DraggableItem : MonoBehaviour, IDraggable, IInteractable {

        [SerializeField] private DroppableTags[] itemTags;

        public static float DistanceToScreen { get; } = 10.0f;

        private bool setOriginalPosition = false;

        private Vector2 originalMousePosition;
        private Vector3 offset, originalPosition;

        private DropZone currentDropZone;
        public RectTransform canvasRectTransform;

        void Start() {
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform,
            //    RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position), Camera.main,
            //    out Vector2 pos2);
            //Vector3 offset = (Vector2)transform.position - (Vector2)canvasRectTransform.TransformPoint(pos2);
            originalPosition = (Vector2)transform.position - (Vector2)canvasRectTransform.TransformPoint(transform.localPosition);
            print(originalPosition);
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, transform.position, Camera.main, out Vector2 pos);
            //transform.position = originalPosition = pos;
            //originalPosition = transform.position;
        }

        public void OnMouseDrag() {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos);
            transform.position = canvasRectTransform.TransformPoint(pos) + offset;
            //Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, DistanceToScreen);
            //transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y); ;
            //transform.localPosition = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }

        public void OnMouseUp() {
            if (currentDropZone != null && currentDropZone.CheckTags(itemTags)) {
                Drop(currentDropZone);
            } else Return();
            currentDropZone = null;
        }

        public void Return() {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform,
                RectTransformUtility.WorldToScreenPoint(Camera.main, originalPosition), Camera.main,
                out Vector2 pos2);
            //transform.localPosition = RectTransformUtility.WorldToScreenPoint(Camera.main, originalPosition);
            transform.position = transform.TransformPoint(originalPosition);
        }

        public void Drop(DropZone drop) {
            //gameObject.transform.localPosition = new Vector3(drop.transform.localPosition.x, drop.transform.localPosition.y, drop.transform.localPosition.z - 0.000001f);
        }
        private void OnTriggerStay(Collider collision) {
            //currentDropZone = collision.transform.GetComponent<DropZone>();

        }
        private void OnTriggerExit(Collider collision) {
            //currentDropZone = null;
        }

        public void ActivateInteractable() {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos)) {
                offset = (Vector2)transform.position - (Vector2)canvasRectTransform.TransformPoint(pos);
                    //transform.SetParent(canvasRectTransform, true);
                //if (setOriginalPosition) return;
                
                
                print(originalPosition);
                setOriginalPosition = true;
            }
        }
    }
}
