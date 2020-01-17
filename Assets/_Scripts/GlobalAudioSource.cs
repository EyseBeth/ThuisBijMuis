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

    private AudioSource audioSource;

    public void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(clip);
    }

    public bool IsPlaying()
    {

        return audioSource.isPlaying;
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
