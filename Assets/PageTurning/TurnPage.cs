using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.PageTurning
{
    public class TurnPage : MonoBehaviour
    {
        [SerializeField]
        private bool backPage = false;

        private BookController bookController;

        private readonly float pageTurnTime = 1;
        private float pivotNumber;

        private Vector3 rot = Vector3.zero;
        private Quaternion targetRotation = Quaternion.identity;

        private Transform pivot = null;

        private void Start()
        {
            bookController = transform.parent.parent.GetComponent<BookController>();
            if (bookController == null) Debug.LogError("No BookController found on parent: " + name);

            pivot = transform.parent;
            if (pivot == null) Debug.LogError("No pivot found on page: " + name);

            if (backPage) rot.z = 0;
            else rot.z = 180;

            targetRotation.eulerAngles = rot;

            pivotNumber = pivot.GetComponent<PagePivot>().PivotNumber;

            transform.localPosition = new Vector3(transform.localPosition.x, -pivotNumber / 1000, transform.localPosition.z);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(0, 0.0001f, 0);
            }
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(0) && !bookController.isCurrentlyTurningPage)
            {
                StartCoroutine(PageTurner());
            }
        }

        private IEnumerator PageTurner()
        {
            bookController.SetTurningPage(true);
            if (backPage) bookController.ChangeCurrentPage(false);
            else bookController.ChangeCurrentPage(true);

            Quaternion currentRosPivot = pivot.rotation;
            float time = 0;
            float amountTurned = 0;
            bool movedPos = false;
            while (amountTurned < 1)
            {

                amountTurned = time / pageTurnTime;
                pivot.rotation = Quaternion.Lerp(currentRosPivot, targetRotation, amountTurned);

                time += Time.deltaTime;

                if (!movedPos && amountTurned > 0.5f)
                {
                    pivot.transform.position = new Vector3(0, pivotNumber / 1000, 0);
                    if (backPage) pivot.transform.position *= -1;
                    movedPos = true;
                }

                yield return new WaitForEndOfFrame();
            }

            bookController.PageTurnEnd();
            bookController.SetTurningPage(false);
        }

        public void SetChildrenActive(bool state)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }
    }
}
