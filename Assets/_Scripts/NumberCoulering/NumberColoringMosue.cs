using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberColoringMosue : MonoBehaviour
{
    [SerializeField]
    Transform obj = null;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = 10f;
        obj.position = Camera.main.ScreenToWorldPoint(mousepos);
    }
}
