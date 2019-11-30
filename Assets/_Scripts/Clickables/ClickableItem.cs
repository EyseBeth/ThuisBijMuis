using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using ThuisBijMuis.Games.Interactables.Indicators;
using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class ClickableItem : MonoBehaviour
    {
        [SerializeField] private ClickableScriptableObject data;

        private AudioSource audioSource;
        private Animator animator;
        private IClickableCustomBehaviour clickableCustomBehaviour;
        private ClickableIndicatorBase clickableIndicator;

        private AudioClip voiceClip;
        private AudioClip soundClip;

        [HideInInspector] public UnityEvent OnClickEvent;
        public bool IsSelected { get; private set; }

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            clickableCustomBehaviour = GetComponent<IClickableCustomBehaviour>();
            clickableIndicator = GetComponent<ClickableIndicatorBase>();

            if (data != null)
            {
                if (data.onSelectVoice != null)
                    voiceClip = data.onSelectVoice;

                if (data.onSelectSound != null)
                    soundClip = data.onSelectSound; 
            }

            if (audioSource == null && (voiceClip != null || soundClip != null))
                audioSource = gameObject.AddComponent<AudioSource>();

            IsSelected = false;

            ClickableItem[] clickables = FindObjectsOfType<ClickableItem>();

            for (int i = 0; i < clickables.Length; i++)
            {
                if (clickables[i].transform != this.transform)
                    clickables[i].OnClickEvent.AddListener(NewSelection);
            }
        }

        private void Execute()
        {
            IsSelected = true;

            if (audioSource != null && !audioSource.isPlaying)
            {
                if (voiceClip != null)
                    audioSource.PlayOneShot(data.onSelectVoice);

                if (soundClip != null)
                    audioSource.PlayOneShot(data.onSelectSound);
            }

            if (animator != null && !animator.GetBool("OnSelect"))
                animator.SetBool("OnSelect", true);

            if (clickableCustomBehaviour != null)
                clickableCustomBehaviour.ExecuteCustomBehaviour();

            clickableIndicator.Pause();
        }

        public void AnimationEnded()
        {
            IsSelected = false;

            animator.SetBool("OnSelect", false);

            if (clickableCustomBehaviour != null)
                clickableCustomBehaviour.EndCustomBehaviour();

            clickableIndicator.UnPause();
        }

        private void NewSelection()
        {
            if (IsSelected)
                IsSelected = false;
        }

        // OnMouseDown also works with touch as long as Input.simulateMouseWithTouch is enabled.
        private void OnMouseDown()
        {
            OnClickEvent.Invoke();
            Execute();
        }
    }
}
