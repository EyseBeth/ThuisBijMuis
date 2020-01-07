using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    [RequireComponent(typeof(AudioSource))]
    public class ClickableAudio : MonoBehaviour, IClickable
    {
        [SerializeField] private AudioClipObject clip;

        private AudioSource audioSource;

        private void Start() => audioSource = GetComponent<AudioSource>();

        public void ExecuteCustomBehaviour()
        {
            if (!audioSource.isPlaying && clip)
                audioSource.PlayOneShot(clip.audioClip[clip.counter++]);

            if (clip.counter >= clip.audioClip.Length)
                clip.counter = clip.audioClip.Length - 1;
        }
    }
}
