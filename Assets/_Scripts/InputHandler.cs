using UnityEngine;
namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class InputHandler : MonoBehaviour
    {
        private Camera mainCamera;
        public GameObject Selection { get; private set; }
        public static InputHandler Singleton { get; private set; }
        public bool HasSelection { get; private set; }
        private void Awake() => Singleton = this;

        void Start()
        {
            Application.targetFrameRate = 300; //Sets the target frame-rate higher for smoother game-play
            Input.multiTouchEnabled = false; //Prevents multitouch due to page transition errors
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Selection = CheckedForClickedObject();
                ActivateSelection();
                SetHasSelection(Selection ? true : false);
            }
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonUp(0))
            {
                ReleaseSelection();
                SetHasSelection(false);
            }
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
            Selection?.GetComponent<IReleasable>()?.ReleaseInteractable();
            Selection = null;
        }

        private void SetHasSelection(bool value)
        {
            HasSelection = value;
            Debug.Log(value);
        }
    }
}