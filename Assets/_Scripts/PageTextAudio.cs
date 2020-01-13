using System.Collections;
using System.Collections.Generic;
using ThuisBijMuis.Games.PageSliding;
using UnityEngine;

#pragma warning disable 0649
[RequireComponent(typeof(AudioSource))]
public class PageTextAudio : MonoBehaviour, IPageActivatable
{
    [SerializeField] private List<AudioObject> pageAudioFiles=new List<AudioObject>();

    private List<bool> playedPages=new List<bool>();
    private PageSlider pageSlider;
    private AudioSource audioSource;
    private bool shouldPlayInstructions;

    public int PageNumber { get; set; }

    private void Start()
    {
        for (int i = 0; i < pageAudioFiles.Count; i++)
        {
            playedPages.Add(false);
        }

        pageSlider = GetComponent<PageSlider>();
        pageSlider.OnPageSlideEnd.AddListener(PlayPageAudio);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (shouldPlayInstructions && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(pageAudioFiles[PageNumber].instruction);
            shouldPlayInstructions = false;
        }
    }

    private void PlayPageAudio()
    {
        if (playedPages[PageNumber])
            return;

        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.PlayOneShot(pageAudioFiles[PageNumber].rhyme);
        playedPages[PageNumber] = true;
        shouldPlayInstructions = true;
    }

    public void CheckPage(int pageNumber) => PageNumber = --pageNumber;

    [System.Serializable]
    struct AudioObject
    {
        public AudioClip rhyme;
        public AudioClip instruction;
    }
}
