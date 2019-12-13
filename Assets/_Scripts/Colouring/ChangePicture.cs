using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThuisBijMuis.Timers;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangePicture : MonoBehaviour
{
    // Start is called before the first frame update
    Timer checkTextureTimer = null;
    [SerializeField]
    private RenderTexture renderTexture;
    [SerializeField]
    private Sprite newImage;
    private Image image;

    void Start()
    {
        checkTextureTimer = new Timer(0.2f, true);
        checkTextureTimer.OnTimerEnd += CheckTexture;

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() => checkTextureTimer?.Tick(Time.deltaTime);

    private void CheckTexture()
    {
        if (TextureFillChecker.CheckTextureFillPercentage(80, Color.black, renderTexture)) PictureChange();
    }

    private void PictureChange()
    {
        image.sprite = newImage;
        checkTextureTimer = null;
        ColourPlacing.ClearSprites();
    }
}
