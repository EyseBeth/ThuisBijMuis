using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ThuisBijMuis.Games.Interactables {
#pragma warning disable 0649
    public class DraggableReplaceItem : DraggableItem {
        [SerializeField] private Sprite draggingSprite;
        private Sprite restingSprite;
        private SpriteRenderer render;

        public override void Start() {
            base.Start();
            render = GetComponent<SpriteRenderer>();
            restingSprite = render.sprite;
        }
        public override void FixedUpdate() {
            base.FixedUpdate();
            render.sprite = selected ? draggingSprite : restingSprite;
        }
    }
}