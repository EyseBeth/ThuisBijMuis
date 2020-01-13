using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    private int pageIndex = 0;
    public int PageIndex { get => pageIndex; set => pageIndex = value; }

    // Start is called before the first frame update
    void Awake()
    { 
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            PageIndex = (transform.parent.GetChild(i) == transform) ? i : 0;
        }
    }
}
