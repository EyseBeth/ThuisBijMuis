using System.Collections;
using System.Collections.Generic;
using ThuisBijMuis.Games.PageSliding;
using UnityEngine;

#pragma warning disable 0649
public class PageTextAudio : MonoBehaviour, IPageActivatable
{
    [SerializeField] private List<AudioObject> pageAudioFiles=new List<AudioObject>();
    [SerializeField] private List<GameObject> instructionsButtons = new List<GameObject>();

    private List<bool> playedPages=new List<bool>();
    private PageSlider pageSlider;
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
    }

    private void Update()
    {
        if (shouldPlayInstructions && !GlobalAudioSource.Instance.IsPlaying())
        {
            GlobalAudioSource.Instance.PlayAudio(pageAudioFiles[PageNumber].instruction);
            shouldPlayInstructions = false;

            if (!instructionsButtons[PageNumber].activeSelf)
                instructionsButtons[PageNumber].SetActive(true);

        }
    }

    private void PlayPageAudio()
    {
        if (GlobalAudioSource.Instance.IsPlaying())
        {
            GlobalAudioSource.Instance.Stop();
            shouldPlayInstructions = false;
        }

        if (playedPages[PageNumber])
        {
            if (!instructionsButtons[PageNumber].activeSelf)
                instructionsButtons[PageNumber].SetActive(true);

            return;
        }

        GlobalAudioSource.Instance.PlayAudio(pageAudioFiles[PageNumber].rhyme);
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
