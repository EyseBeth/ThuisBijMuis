﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    public class DraggableAudio : DraggableItem
    {
        [SerializeField] private AudioClipObject clip;

        public override void Release()
        {
            if (currentDropZone != null && currentDropZone.CheckTags(ItemTags))
            {
                Drop(currentDropZone);
                PlayAudio();
            }
            else Return();
            currentDropZone = null;
            selected = false;
        }

        private void PlayAudio()
        {
            if (!GlobalAudioSource.Instance.AudioSource.isPlaying && clip)
                GlobalAudioSource.Instance.AudioSource.PlayOneShot(clip.audioClip[clip.counter++]);

            if (clip.counter >= clip.audioClip.Length)
                clip.counter = clip.audioClip.Length - 1;
        }
    }
}