using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ThuisBijMuis.Games.Interactables.PageTurning {
#pragma warning disable 0649

    public class BookController : MonoBehaviour {
        public bool isCurrentlyTurningPage = false;
        private int index = -1;
        private readonly List<TurnPage> allPages = new List<TurnPage>();

        private void Start() {
            for (int i = 0; i < transform.childCount; i++) {
                Transform pivot = transform.GetChild(i);
                for (int j = 0; j < pivot.transform.childCount; j++) {
                    TurnPage page = pivot.GetChild(j).GetComponent<TurnPage>();
                    if (page) {
                        allPages.Add(page);
                    }
                }
            }
            PageTurnEnd();
        }

        public void SetTurningPage(bool value) {
            isCurrentlyTurningPage = value;
        }

        public void ChangeCurrentPage(bool next) {
            if (next) index += 2;
            else index -= 2;

            if (index > 0) allPages[index].SetChildrenActive(true);
            if (index < allPages.Count - 1) allPages[index + 1].SetChildrenActive(true);

        }

        public void PageTurnEnd() {
            if (index > 1) allPages[index - 2].SetChildrenActive(false);
            if (index > 0) allPages[index - 1].SetChildrenActive(false);
            if (index < allPages.Count - 2) allPages[index + 2].SetChildrenActive(false);
            if (index < allPages.Count - 3) allPages[index + 3].SetChildrenActive(false);

        }

        public int GetPivotNumber(Transform pivot) {
            for (int i = 0; i < transform.childCount; i++) {
                if (transform.GetChild(i) == pivot) return i;
            }
            Debug.LogError("Pivot not a child of BookController");
            return 0;
        }
    }
}
