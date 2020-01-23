using UnityEngine;

namespace ThuisBijMuis.Games.Interactables
{
#pragma warning disable 0649
    public class UpdateZone : DropZone
    {
        [SerializeField] private Sprite[] zoneReplace;
        
        private int counter;
        private SpriteRenderer spriteRenderer;

        private void Start() => spriteRenderer = GetComponent<SpriteRenderer>();

        private void Update()
        {
            if (IsDropped)
            {
                IsDropped = false;
                counter++;
                spriteRenderer.sprite = zoneReplace[counter];
            }
        }
    }
}
