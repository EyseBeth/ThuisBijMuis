using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageTransition : MonoBehaviour
{
    public Image fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.canvasRenderer.SetAlpha(0.5f);

        FadeOut();
    }

    public void FadeOut()
    {
        fade.CrossFadeAlpha(0, 2, false);
        fade.canvasRenderer.SetAlpha(0.5f);
        //  fade.gameObject.SetActive(false);
        //  Destroy(fade,2);
    }
    public void FadeIn()
    {
        fade.CrossFadeAlpha(1, 2, false);
        fade.canvasRenderer.SetAlpha(2.0f);

        FadeOut();

    }

}
