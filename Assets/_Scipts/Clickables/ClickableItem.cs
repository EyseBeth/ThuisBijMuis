using UnityEngine;

namespace ThuisBijMuis.Clickables
{
#pragma warning disable 0649
    public class ClickableItem : MonoBehaviour
    {
        [SerializeField] private ClickableScriptableObject data;

        private AudioSource audioSource;
        private Animator animator;
        private IClickableCustomBehaviour clickableCustomBehaviour;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
            clickableCustomBehaviour = GetComponent<IClickableCustomBehaviour>();
        }

        public void Execute()
        {
            AudioClip voiceClip = null;
            AudioClip soundClip = null;

            if (data.onSelectVoice != null)
                voiceClip = data.onSelectVoice;

            if (data.onSelectSound != null)
                soundClip = data.onSelectSound;

            if (audioSource == null && (voiceClip != null || soundClip != null))
                audioSource = gameObject.AddComponent<AudioSource>();

            if (!audioSource.isPlaying)
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
        }

        public void AnimationEnded()
        {
            animator.SetBool("OnSelect", false);
        }
    }
}
