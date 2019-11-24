using UnityEngine;

namespace ThuisBijMuis.Clickables
{
    [CreateAssetMenu(fileName = "New clickable item", menuName = "Clickable item")]
    public class ClickableScriptableObject : ScriptableObject
    {
        public AudioClip onSelectSound;
        public AudioClip onSelectVoice;
    }
}