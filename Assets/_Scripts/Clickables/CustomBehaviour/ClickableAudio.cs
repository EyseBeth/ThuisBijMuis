using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    public class ClickableAudio : MonoBehaviour, IClickable
    {
        [SerializeField] private AudioClipObject clip;

        public void ExecuteCustomBehaviour()
        {
            if (clip) GlobalAudioSource.Instance.PlayAudio(clip.audioClip[clip.counter++]);
            if (clip.counter >= clip.audioClip.Length) clip.counter = clip.audioClip.Length - 1;
        }
    }
}
