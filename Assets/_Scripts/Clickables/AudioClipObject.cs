using System;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
    [CreateAssetMenu(fileName = "New AudioClip", menuName = "AudioClip for object type")]
    public class AudioClipObject : ScriptableObject
    {
        public AudioClip[] audioClip;
        [HideInInspector, NonSerialized] public int counter;
    }
}