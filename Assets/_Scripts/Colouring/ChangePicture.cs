using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThuisBijMuis.Timers;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[RequireComponent(typeof(Image))]
public class ChangePicture : MonoBehaviour
{
    // Start is called before the first frame update
    Timer checkTextureTimer = null;
    [SerializeField]
    private RenderTexture renderTexture;
    [SerializeField]
    private Sprite newImage;
    [SerializeField]
    private Color colorToCheckFor;
    [SerializeField]
    private float percentageToFill;
    private Image image;
    private bool firstCheck;

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
        if (TextureFillChecker.CheckTextureFillPercentage(percentageToFill, colorToCheckFor, renderTexture)) PictureChange();
    }

    private void PictureChange()
    {
        image.sprite = newImage;
        checkTextureTimer = null;
        ColourPlacing.ClearSprites();
    }
}
