using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.PageTurning {
    public class TurnPage : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private bool backPage = false;

        private BookController bookController;

        private readonly float pageTurnTime = 2;
        private float pivotNumber;

        private Vector3 rot = Vector3.zero;
        private Quaternion targetRotation = Quaternion.identity;
        private Quaternion currentRotation = Quaternion.identity;

        private float time;

        private Transform pivot = null;
        private bool isClicked = false;
        private bool firstUpdate = false;

        private void Start()
        {
            try { bookController = transform.parent.parent.GetComponent<BookController>(); }
            catch (System.Exception e) { throw e; }

            try { pivot = transform.parent; }
            catch (System.Exception e) { throw e; }

            if (backPage) rot.y = 0;
            else rot.y = -180;

            targetRotation.eulerAngles = rot;

            pivotNumber = bookController.GetPivotNumber(pivot);

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, (pivotNumber + 1) / 1000);

            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).localPosition = new Vector3(0, 0, -0.001f);
            }
        }

        private void Update()
        {
            if (isClicked)
            {
                if (!firstUpdate)
                {
                    currentRotation = pivot.localRotation;
                    FirstUpdate();
                    firstUpdate = true;
                }

                if (PageLerp(pageTurnTime)) //Lerp Done
                {
                    bookController.SetTurningPage(false);
                    bookController.PageTurnEnd();
                }
            }
        }


        private void FirstUpdate()
        {
            bookController.SetTurningPage(true);
            if (backPage) bookController.ChangeCurrentPage(false);
            else bookController.ChangeCurrentPage(true);
        }

        private bool PageLerp(float duration)
        {
            if (time < 1)
            {
                time += Time.deltaTime / duration;
                pivot.localRotation = Quaternion.Lerp(currentRotation, targetRotation, time);
                return false;
            }
            else
            {
                time = 0;
                firstUpdate = false;
                isClicked = false;
                return true;
            }
        }

        public void SetChildrenActive(bool state)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }

        public void ActivateInteractable() {
            if (!bookController.isCurrentlyTurningPage) {
                isClicked = true;
            }
        }
    }
}
