using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public class DraggableItem : MonoBehaviour, IDraggable, IReleasable {

        [SerializeField] protected List<DroppableTags> ItemTags;
        [SerializeField] private RectTransform canvasRectTransform;

        protected bool selected = false;
        private Vector3 originalPosition;
        protected DropZone currentDropZone;

        //Sets the originalPosition at start to be used in the snap back when the object is released where it is not allowed
        private void Start() {
            originalPosition = transform.localPosition;
        }

        public void FixedUpdate() {
            if (selected) Drag();
        }

        //Changes the position of the object based on the users touch position relative to the screen position
        public void Drag() {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, Input.mousePosition, Camera.main, out Vector2 pos);
            transform.position = canvasRectTransform.TransformPoint(pos);
        }

        //When the object is released it checks whether it is on a drop zone and if it is, whether the tags are accepted
        public virtual void Release() {
            if (currentDropZone != null && currentDropZone.CheckTags(ItemTags)) {
                Drop(currentDropZone);
            } else Return();
            currentDropZone = null;
            selected = false;
        }

        //If the drop position is unacceptable the item snaps back to its position of origin
        public void Return() {
            transform.localPosition = originalPosition;
        }

        //If the drop position is acceptable the items position is snapped to the dropzone's position
        public void Drop(DropZone drop) {
            transform.localPosition = new Vector3(drop.transform.localPosition.x, drop.transform.localPosition.y, drop.transform.localPosition.z - 0.000001f);
            currentDropZone.IsDropped = true;
        }
        // ReSharper disable UnusedMember.Local
        private void OnTriggerEnter(Collider collision) {
            currentDropZone = collision.transform.GetComponent<DropZone>();

        }
        private void OnTriggerExit(Collider collision) {
            if (currentDropZone) currentDropZone.IsDropped = false;
            currentDropZone = null;
        }

        public void ActivateInteractable() {
            selected = true;
        }

        public void ReleaseInteractable() {
            Release();
        }
    }
}
