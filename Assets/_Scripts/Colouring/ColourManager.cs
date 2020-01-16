using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThuisBijMuis.Games.PageSliding;


namespace ThuisBijMuis.Games.Colouring
{

#pragma warning disable 0649
    /// <summary>
    /// This class exists to manage the colourplacing and centralize the variables used.
    /// This makes life easier for new isntances of the prefab
    /// </summary>
    public class ColourManager : MonoBehaviour, IPageActivatable
    {
        [SerializeField]
        private SpriteRenderer spriteToColourWith;
        [SerializeField]
        private Color colour;
        [SerializeField]
        private Camera colourCamera;
        [SerializeField]
        private Sprite imageToReplace;
        [SerializeField]
        private Sprite newImage;
        [SerializeField]
        private Sprite mask;
        [SerializeField]
        private float percentageToFill;

        public int PageNumber { get; set; } = -1;

        private Sprite currentSprite;
        private SpriteMask spriteMask;
        private SpriteRenderer spriteRenderer;
        private ChangePicture changePicture;
        private ColourPlacing colourPlacing;

        private void Start() => PageNumber = GetComponentInParent<Page>().PageIndex;

        public void CheckPage(int pageNumber)
        {
            Debug.Log("@CheckPage - " + pageNumber + " - " + PageNumber);
            if (pageNumber == PageNumber)
            {
                Debug.Log("Setup RUN!");
                Setup();
                colourPlacing.StartPlacing();
                changePicture.ActivateTimer();
            }
            else
            {
                colourPlacing?.StopPlacing();
                changePicture?.DisableTimer();
            }
        }

        private void Setup()
        {
            spriteMask = GetComponentInChildren<SpriteMask>();
            changePicture = GetComponentInChildren<ChangePicture>();
            colourPlacing = GetComponentInChildren<ColourPlacing>();
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            colourPlacing.OnCompletionEvent.AddListener(OnEnd);

            spriteRenderer.sprite = imageToReplace;

            colourPlacing.ColourCamera = colourCamera;
            colourPlacing.ColourSprite = spriteToColourWith.gameObject;
            spriteToColourWith.color = colour;

            spriteMask.sprite = mask;
            spriteMask.alphaCutoff = 1f;

            changePicture.NewImage = newImage;
            changePicture.ColourPlacing = colourPlacing;
            changePicture.RenderTexture = colourCamera.targetTexture;
            changePicture.ColorToCheckFor = spriteToColourWith.color;

            changePicture.PercentageToFill = percentageToFill;
        }

        public void OnEnd()
        {
            spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            spriteMask.gameObject.SetActive(false);
        }
    }
}
