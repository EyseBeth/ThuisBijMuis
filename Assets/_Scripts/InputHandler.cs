using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class InputHandler : MonoBehaviour
    {
        private Camera mainCamera;

        public GameObject Selection { get; private set; }
        public static InputHandler Singleton { get; private set; }

        private void Awake() => Singleton = this;

        private void Start()
        {
            // Sets the target frame-rate higher for smoother game-play.
            Application.targetFrameRate = 300;

            // Prevents multitouch due to page transition errors.
            Input.multiTouchEnabled = false;
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Selection = CheckedForClickedObject();
                ActivateSelection();
            }
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonUp(0)) ReleaseSelection();
        }

        //Returns the gameobject hit by the raycast
        private GameObject CheckedForClickedObject()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out RaycastHit hit) ? hit.collider.gameObject : null;
        }

        //If the selected gameobject is an IInteractable it will activate it
        private void ActivateSelection() => Selection?.GetComponent<IInteractable>()?.ActivateInteractable();

        //If the released gameobject is an IReleasable it will activate its release function and set the selection to null
        private void ReleaseSelection()
        {
            if (!Selection)
                return;

            foreach (IReleasable releaseables in Selection.GetComponents<IReleasable>())
                releaseables.ReleaseInteractable();

            Selection = null;
        }
    }
}