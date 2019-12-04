using UnityEngine;
namespace ThuisBijMuis.Games.Interactables {
    public class InputHandler : MonoBehaviour {

        private Camera mainCamera;
        void Start() {
            mainCamera = Camera.main;
        }

        void Update() {
            if (Input.GetMouseButtonDown(0)) {
                GameObject mouseSelection = CheckForObjectUnderMouse();
                ActivateMouseSelection(mouseSelection);
            }
        }

        private GameObject CheckForObjectUnderMouse() {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out RaycastHit hit) ? hit.collider.gameObject : null;
        }

        private void ActivateMouseSelection(GameObject selection) {
            selection?.GetComponent<IInteractable>()?.ActivateInteractable();
        }
    }
}