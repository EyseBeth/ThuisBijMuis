using UnityEngine;

namespace ThuisBijMuis.Clickables
{
#pragma warning disable 0649
    public class ClickableController : MonoBehaviour
    {
        [SerializeField] private ClickableIndicatorEnum.IndicatorType clickableIndicatorType;
        [SerializeField] private LayerMask clickableLayer;

        private Camera cam;

        private void Awake()
        {
            // Find all clickable items and add the indicator to them.
            ClickableItem[] clickableItems = FindObjectsOfType<ClickableItem>();
            for (int i = 0; i < clickableItems.Length; i++)
            {
                GameObject obj = clickableItems[i].gameObject;

                switch (clickableIndicatorType)
                {
                    case ClickableIndicatorEnum.IndicatorType.Outline:
                        // Add outline component.
                        break;
                }
            }

            cam = Camera.main;
        }

        private void Update()
        {
            // Temp while we work without touch.
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                Debug.DrawLine(ray.origin, ray.direction * 20, Color.red, 2f);
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, clickableLayer))
                {
                    GameObject hitObject = hitInfo.collider.gameObject;
                    ClickableItem item = hitObject.GetComponent<ClickableItem>();
                    item.Execute();
                }
            }
        }
    }
}