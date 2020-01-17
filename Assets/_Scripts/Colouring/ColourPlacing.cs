using System.Collections;
using System.Collections.Generic;
using ThuisBijMuis.Games.PageSliding;
using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.Colouring
{
#pragma warning disable 0649
    public class ColourPlacing : MonoBehaviour
    {
        private bool firstPlace;
        private bool ableToPlace = false;
        public GameObject ColourSprite { private get; set; }
        private List<GameObject> spriteList = new List<GameObject>();
        public Camera ColourCamera { private get; set; }
        private Camera cam;

        public UnityEvent OnStartEvent = new UnityEvent();
        public UnityEvent OnCompletionEvent = new UnityEvent();

        // Start is called before the first frame update
        void Start() => cam = Camera.main;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0) && ableToPlace)
            {
                Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = -.1f;
                if (IsPositionInCameraView(ColourCamera, mousePos)) PlaceColour(mousePos);
                else Debug.Log("Not In View!");
            }
            else if (Input.GetMouseButton(0) && !ableToPlace) Debug.Log("Not able to place!");
        }

        /// <summary>
        /// Checks wether or not a position is in view for a camera
        /// </summary>
        /// <param name="cam">The Camera to check for</param>
        /// <param name="pos">The position that needs to be checked</param>
        /// <returns>True if the position is in view</returns>
        private bool IsPositionInCameraView(Camera cam, Vector3 pos)
        {
            Vector3 viewPos = cam.WorldToViewportPoint(pos);
            return viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0;
        }

        private void PlaceColour(Vector3 position)
        {
            Debug.Log("Placed Colour");
            spriteList.Add(Instantiate(ColourSprite, position, Quaternion.identity, transform));
            if (firstPlace)
            {
                firstPlace = false;
                OnStartEvent?.Invoke();
            }
        }

        /// <summary>
        /// Clears all the sprites/colour on the screen
        /// </summary>
        public void ClearSprites()
        {
            foreach (GameObject s in spriteList) Destroy(s);

            spriteList.Clear();
            ableToPlace = false;

            OnCompletionEvent?.Invoke();
        }

        public void StartPlacing() => ableToPlace = true;

        public void StopPlacing() => ableToPlace = false;
    }

}