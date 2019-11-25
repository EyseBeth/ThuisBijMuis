using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThuisBijMuis.PageTurning
{
    public class BookController : MonoBehaviour
    {
        public bool isCurrentlyTurningPage = false;
        private int index = -1;
        [SerializeField]
        private TurnPage[] allPages;

        public void SetTurningPage(bool value)
        {
            isCurrentlyTurningPage = value;
        }

        public void ChangeCurrentPage(bool next)
        {
            if (next) index += 2;
            else index -= 2;

            if (index > 0) allPages[index].SetChildrenActive(true);
            if (index < allPages.Length - 1) allPages[index + 1].SetChildrenActive(true);
        }

        public void PageTurnEnd()
        {
            if (index > 1) allPages[index - 2].SetChildrenActive(false);
            if (index > 0) allPages[index - 1].SetChildrenActive(false);
            if (index < allPages.Length - 2) allPages[index + 2].SetChildrenActive(false);
            if (index < allPages.Length - 3) allPages[index + 3].SetChildrenActive(false);
        }
    }
}
