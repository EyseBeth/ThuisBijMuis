using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColourPlacing : MonoBehaviour
{
    [SerializeField]
    private GameObject colourSprite;
    private Camera cam;
    public static bool ableToPlace = true;
    private static List<GameObject> spriteList = new List<GameObject>();

    // Start is called before the first frame update
    void Start() => cam = GetComponent<Camera>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ableToPlace)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            PlaceColour(mousePos);
        }
    }

    private void PlaceColour(Vector3 position)
    {
        spriteList.Add(Instantiate(colourSprite, position, Quaternion.identity));
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


}
