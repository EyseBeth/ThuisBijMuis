using UnityEngine;

namespace ThuisBijMuis.Games.PageSliding
{
    [RequireComponent(typeof(Canvas))]
    public class SetCanvasCamera : MonoBehaviour
    {
        private Canvas canvas;
        //Sets the canvas camera and rendermode to the correct modes
        void Start()
        {
            canvas = GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.main;
        }
    } 
}
