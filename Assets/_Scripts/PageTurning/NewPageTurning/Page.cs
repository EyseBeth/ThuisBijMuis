using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    private int pageIndex = 0;
    public int PageIndex { get => pageIndex; set => pageIndex = value; }

    void Awake()
    { 
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if(transform.parent.GetChild(i) == transform) pageIndex = i;
        }
    }
}
