using UnityEngine;

namespace ThuisBijMuis.Clickables.CustomBehaviours
{
    public class ChangeColor : MonoBehaviour, IClickableCustomBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private bool changeColor = false;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (changeColor)
            {
                spriteRenderer.color = new Color(Random.value, Random.value, Random.value);
            }
        }

        public void ExecuteCustomBehaviour()
        {
            changeColor = true;
        }

        public void EndCustomBehaviour()
        {
            changeColor = false;    
        }
    } 
}
