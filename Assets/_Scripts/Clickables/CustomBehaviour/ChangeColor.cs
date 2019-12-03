using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    [RequireComponent(typeof(ClickableAnimation), typeof(SpriteRenderer))]
    public class ChangeColor : MonoBehaviour, IClickable
    {
        private SpriteRenderer spriteRenderer;
        private ClickableAnimation clickableAnimation;
        private bool changeColor = false;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            // Want to stop the changing of color when the animation end so we need a reference
            // to the script. When we get a reference we add our stop as a listener to the event.
            clickableAnimation = GetComponent<ClickableAnimation>();
            clickableAnimation.OnAnimationEndedEvent.AddListener(StopChangeColor);
        }

        private void Update()
        {
            if (changeColor)
                spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
        }

        public void ExecuteCustomBehaviour()
        {
            changeColor = true;
        }

        private void StopChangeColor()
        {
            changeColor = false;    
        }
    } 
}
