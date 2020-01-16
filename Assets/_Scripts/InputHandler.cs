using UnityEngine;
namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    public class InputHandler : MonoBehaviour {

        private Camera mainCamera;
        private GameObject selection;
        void Start() {
            Application.targetFrameRate = 300; //Sets the target frame-rate higher for smoother game-play
            Input.multiTouchEnabled = false; //Prevents multitouch due to page transition errors
            mainCamera = Camera.main;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                selection = CheckedForClickedObject();
                ActivateSelection();
            } else if (Input.GetMouseButtonUp(0)) ReleaseSelection();
        }

        //Returns the gameobject hit by the raycast
        private GameObject CheckedForClickedObject() {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out RaycastHit hit) ? hit.collider.gameObject : null;
        }

        //If the selected gameobject is an IInteractable it will activate it
        private void ActivateSelection() {
            selection?.GetComponent<IInteractable>()?.ActivateInteractable();
        }

        //If the released gameobject is an IReleasable it will activate its release function and set the selection to null
        private void ReleaseSelection() {
            if (!selection)
                return;

            foreach (IReleasable releaseables in selection.GetComponents<IReleasable>())
                releaseables.ReleaseInteractable();

            selection = null;
        }
    }
}