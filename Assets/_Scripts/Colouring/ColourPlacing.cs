using System.Collections;
using System.Collections.Generic;
using ThuisBijMuis.Games.PageSliding;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class ColourPlacing : MonoBehaviour, IPageActivatable
{
    [SerializeField]
    private GameObject colourSprite;
    [SerializeField]
    private int pageNumber;

    public static bool ableToPlace = false;
    private bool firstPlace;

    private static List<GameObject> spriteList = new List<GameObject>();

    private Camera colourCamera;
    private Camera cam;

    private static UnityEvent OnStartEvent = new UnityEvent();
    private static UnityEvent OnCompletionEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        colourCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && ableToPlace)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -.1f;
            if (IsPositionInCameraView(colourCamera, mousePos)) PlaceColour(mousePos);
        }
    }

    /// <summary>
    /// Checks wether or not a position is in view for a camera
    /// </summary>
    /// <param name="cam">The Camera to check for</param>
    /// <param name="pos">The position that needs to be checked</param>
    /// <returns>True if the position is in view</returns>
    private bool IsPositionInCameraView(Camera cam, Vector3 pos)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(pos);
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0) return true;
        return false;
    }

    private void PlaceColour(Vector3 position)
    {
        GameObject temp = Instantiate(colourSprite, position, Quaternion.identity, transform);
        spriteList.Add(temp);
        if (firstPlace)
        {
            firstPlace = false;
            OnStartEvent?.Invoke();
        }
    }

    /// <summary>
    /// Clears all the sprites/colour on the screen
    /// </summary>
    public static void ClearSprites()
    {
        for (int i = 0; i < spriteList.Count; i++)
        {
            Destroy(spriteList[i]);
        }

        spriteList.Clear();
        ableToPlace = false;

        OnCompletionEvent?.Invoke();
    }

    public void CheckPage(int pageNumber) => ableToPlace = this.pageNumber == pageNumber;
}
