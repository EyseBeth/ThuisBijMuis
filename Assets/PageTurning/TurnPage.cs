using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour
{
    [SerializeField]
    private bool backPage = false;
    private bool ableToClick = true;

    private readonly float pageTurnTime = 1;
    private float pivotNumber;

    private Vector3 rot = Vector3.zero;
    private Quaternion targetRotation = Quaternion.identity;

    private Transform pivot = null;

    private void Start()
    {
        pivot = transform.parent;
        if (pivot == null) Debug.LogError("No pivot found on page: " + name);

        if (backPage) rot.z = 0;
        else rot.z = 180;

        targetRotation.eulerAngles = rot;

        pivotNumber = pivot.GetComponent<PagePivot>().PivotNumber;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && ableToClick)
        {
            StartCoroutine(PageTurner());
        }
    }

    private IEnumerator PageTurner()
    {
        ableToClick = false;



        Quaternion currentRosPivot = pivot.rotation;
        float time = 0;
        float amountTurned = 0;
        bool movedPos = false;
        while (amountTurned < 1)
        {
            
            amountTurned = time / pageTurnTime;
            pivot.rotation = Quaternion.Lerp(currentRosPivot, targetRotation, amountTurned);

            time += Time.deltaTime;

            if(!movedPos && amountTurned > 0.5f)
            {
                pivot.transform.position = new Vector3(0, pivotNumber / 1000, 0);
                if (backPage) pivot.transform.position *= -1;
                movedPos = true;
            }

            yield return new WaitForEndOfFrame();
        }



        ableToClick = true;
    }

}
