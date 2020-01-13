using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GlobalAudioSource : MonoBehaviour
{
    #region Singleton
    private static GlobalAudioSource instance;

    public static GlobalAudioSource Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("No GlobalAudioSource script has been foun in the scene!");

            return instance;
        }
    }
    #endregion

    public AudioSource AudioSource { get; private set; }

    public void Awake()
    {
        instance = this;
        AudioSource = GetComponent<AudioSource>();
    }
}
