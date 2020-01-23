using UnityEngine;

namespace ThuisBijMuis.Games
{
    public class NumberColoringMosue : MonoBehaviour
    {
        [SerializeField] Transform obj = null;

        private void Update()
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 10f;
            obj.position = Camera.main.ScreenToWorldPoint(mousepos);
        }
    } 
}
