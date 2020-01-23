using UnityEngine;
using UnityEngine.UI;

namespace ThuisBijMuis.Games
{
#pragma warning disable 0649
    public class PageTransition : MonoBehaviour
    {
        [SerializeField] private Image fade;

        void Start()
        {
            fade.canvasRenderer.SetAlpha(0.5f);
            FadeOut();
        }

        public void FadeOut()
        {
            fade.CrossFadeAlpha(0, 2, false);
            fade.canvasRenderer.SetAlpha(0.5f);
        }

        public void FadeIn()
        {
            fade.CrossFadeAlpha(1, 2, false);
            fade.canvasRenderer.SetAlpha(2.0f);
            FadeOut();
        }
    } 
}
