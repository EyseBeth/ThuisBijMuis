using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    [CreateAssetMenu(fileName = "New AudioClip", menuName = "AudioClip")]
    public class AudioClipObject : ScriptableObject
    {
        public AudioClip audioClip;
    }
}