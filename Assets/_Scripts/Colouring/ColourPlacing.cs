using System.Collections;
using System.Collections.Generic;
using ThuisBijMuis.Games.PageSliding;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColourPlacing : MonoBehaviour, IPageActivatable {
#pragma warning disable 0649
    [SerializeField]
    private GameObject colourSprite;
    [SerializeField]
    private int pageNumber;
    private Camera cam;
    public static bool ableToPlace = false;
    private static List<GameObject> spriteList = new List<GameObject>();

    // Start is called before the first frame update
    void Start() => cam = Camera.main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ableToPlace)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 24.95f;
            PlaceColour(mousePos);
        }
    }

    private void PlaceColour(Vector3 position)
    {
        GameObject temp = Instantiate(colourSprite, position, Quaternion.identity, transform);
        spriteList.Add(temp);
    }

    /// <summary>
    /// Clears all the sprites on the screen
    /// </summary>
    public static void ClearSprites()
    {
        for (int i = 0; i < spriteList.Count; i++)
        {
            Destroy(spriteList[i]);
        }

        spriteList.Clear();
        ableToPlace = false;
    }

    public void CheckPage(int pageNumber)
    {
        if (this.pageNumber == pageNumber) ableToPlace = true;
        else ableToPlace = false;
    }
}
