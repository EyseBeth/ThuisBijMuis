using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class PathObject : MonoBehaviour
    {
        [HideInInspector] public Vector2Event OnTargetClicked;

        private void OnMouseDown()
        {
            OnTargetClicked.Invoke(transform.position);
        }
    }

    [System.Serializable]
    public class Vector2Event : UnityEvent<Vector2>
    {
    }
}