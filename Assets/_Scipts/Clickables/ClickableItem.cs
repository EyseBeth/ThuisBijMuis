using UnityEngine;

namespace ThuisBijMuis.Clickables
{
#pragma warning disable 0649
    public class ClickableItem : MonoBehaviour
    {
        [SerializeField] private ClickableScriptableObject data;

        private AudioSource audioSource;
        private Animator animator;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            animator = GetComponent<Animator>();
        }

        public void Execute()
        {
            if (data.onSelectVoice != null)
            {
                if (audioSource == null)
                    audioSource = gameObject.AddComponent<AudioSource>();

                audioSource.PlayOneShot(data.onSelectVoice);
            }

            if (data.onSelectSound != null)
            {
                if (audioSource == null)
                    audioSource = gameObject.AddComponent<AudioSource>();

                audioSource.PlayOneShot(data.onSelectSound);
            }

            if (animator != null && !animator.GetBool("OnSelect"))
                animator.SetBool("OnSelect", true);
        }

        public void AnimationEnded()
        {
            animator.SetBool("OnSelect", false);
        }
    }
}
