using UnityEngine;
namespace ThuisBijMuis.Games.Interactables {
    public class InputHandler : MonoBehaviour {

        private Camera mainCamera;
        void Start() {
            mainCamera = Camera.main;
        }

        private void Update() {
//#if UNITY_IOS || UNITY_ANDROID
//            if (Input.touchCount <= 0) return;
//            GameObject touchSelection = CheckedForClickedObject();
//            ActivateSelection(touchSelection);
//#else
            if (!Input.GetMouseButtonDown(0)) return;
            GameObject mouseSelection = CheckedForClickedObject();
            ActivateSelection(mouseSelection);
//#endif

        }

        private GameObject CheckedForClickedObject() {
//#if UNITY_IOS || UNITY_ANDROID
//            Ray ray = mainCamera.ScreenPointToRay(Input.GetTouch(0).position);
//#else
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
//#endif
            return Physics.Raycast(ray, out RaycastHit hit) ? hit.collider.gameObject : null;
        }

        private void ActivateSelection(GameObject selection) {
            selection?.GetComponent<IInteractable>()?.ActivateInteractable();
        }
    }
}