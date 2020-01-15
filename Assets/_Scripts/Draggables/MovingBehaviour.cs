using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class MovingBehaviour : MonoBehaviour, IDropBehaviour
    {
        [SerializeField] private GameObject target;
        private float step = 0.25f;

        public void FixedUpdate()
        {
            if (!IsActive) return;
            transform.position =
                Vector3.MoveTowards(transform.position, target.transform.position, step * Time.deltaTime);
            if (!(Vector3.Distance(transform.position, target.transform.position) < 0.05f)) return;
            EndBehaviour();
        }

        public bool IsActive { get; set; }

        public void EndBehaviour()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }
}
