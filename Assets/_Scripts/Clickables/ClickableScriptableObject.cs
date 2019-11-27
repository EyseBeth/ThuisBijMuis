using UnityEngine;

namespace ThuisBijMuis.Games.Interactables {
    [CreateAssetMenu(fileName = "New clickable item", menuName = "Clickable item")]
    public class ClickableScriptableObject : ScriptableObject
    {
        public AudioClip onSelectSound;
        public AudioClip onSelectVoice;
    }
}