using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextureFillChecker
{
    /// <summary>
    /// Checks texture for fill amount
    /// </summary>
    /// <param name="percentage">Percentage of the texture that needs the be filled</param>
    /// <param name="fillColor">Color the texture needs to be filled with</param>
    /// <param name="textureToCheck"></param>
    /// <returns>True if the percentage of the texture has been filled</returns>
    public static bool CheckTextureFillPercentage(float percentage, Color fillColor, Texture2D textureToCheck)
    {
        Mathf.Clamp(percentage, 10, 100);
        percentage /= 100;

        Color[] pixels =  new Color[textureToCheck.width * textureToCheck.height];

        for (int w = 0, i = 0; w < textureToCheck.width; w++)
        {
            for (int h = 0; h < textureToCheck.height; h++, i++)
            {
                pixels[i] = textureToCheck.GetPixel(w, h);
            }
        }

        List<Color> filledPixels = new List<Color>();

        for (int i = 0; i < pixels.Length; i++)
        {
            if (pixels[i] == fillColor) filledPixels.Add(pixels[i]);
        }

        if (filledPixels.Count >= pixels.Length * percentage) return true;
        return false;
    }
    
    public static bool CheckTextureFillPercentage(float percentage, Color fillColor, RenderTexture textureToCheck)
    {
        Texture2D texture2D = ToTexture2D(textureToCheck);
        return CheckTextureFillPercentage(percentage, fillColor, texture2D);
    }

    /// <summary>
    /// Creates a texture2D from a RenderTexture
    /// </summary>
    /// <param name="rTex"></param>
    /// <returns></returns>
    private static Texture2D ToTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
