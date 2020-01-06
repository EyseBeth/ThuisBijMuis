using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class EnableCatch : MonoBehaviour, IClickable
    {
        public bool allowCatch = false;
        public virtual void ExecuteCustomBehaviour()
        {
            allowCatch = true;
        }

        public void OnTriggerEnter(Collider collision)
        {
            if (allowCatch && collision.gameObject.tag == "net")
            {
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}

