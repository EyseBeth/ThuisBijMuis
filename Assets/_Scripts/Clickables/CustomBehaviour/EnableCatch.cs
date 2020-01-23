using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class EnableCatch : MonoBehaviour, IClickable
    {
        private bool allowCatch;

        public virtual void ExecuteCustomBehaviour() => allowCatch = true;

        public void OnTriggerEnter(Collider collision)
        {
            if (!allowCatch || collision.gameObject.tag != "net") return;

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}

