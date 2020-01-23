using UnityEngine;

public class Page : MonoBehaviour
{
    public int PageIndex { get; private set; }

    void Awake()
    {
        for (int i = 0; i < transform.parent.childCount; i++)
            if (transform.parent.GetChild(i) == transform) PageIndex = i;
    }
}
