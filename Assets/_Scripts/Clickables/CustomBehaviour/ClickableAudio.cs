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

        public void ExecuteCustomBehaviour() => audioSource.PlayOneShot(clip.audioClip);
    }
}
