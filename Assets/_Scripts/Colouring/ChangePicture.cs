using ThuisBijMuis.Timers;
using UnityEngine;

namespace ThuisBijMuis.Games.Colouring
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class ChangePicture : MonoBehaviour
    {
        // Start is called before the first frame update
        Timer checkTextureTimer = null;
        public RenderTexture RenderTexture { get; set; }
        public Sprite NewImage { get; set; }
        public Color ColorToCheckFor { get; set; }
        public float PercentageToFill { get; set; }
        private SpriteRenderer SpriteComponent;
        public ColourPlacing ColourPlacing { get; set; }

        // Update is called once per frame
        void Update() => checkTextureTimer?.Tick(Time.deltaTime);

        private void CheckTexture()
        {
            if (TextureFillChecker.CheckTextureFillPercentage(PercentageToFill, ColorToCheckFor, RenderTexture)) PictureChange();
        }

        private void PictureChange()
        {
            SpriteComponent.sprite = NewImage;
            checkTextureTimer = null;
            ColourPlacing.ClearSprites();
        }

        public void ActivateTimer()
        {
            checkTextureTimer = new Timer(0.2f, true);
            checkTextureTimer.OnTimerEnd += CheckTexture;

            SpriteComponent = GetComponent<SpriteRenderer>();
        }

        public void DisableTimer() => checkTextureTimer = null;
    }
}