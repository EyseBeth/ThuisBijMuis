using ThuisBijMuis.Games.Interactables.Indicators;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    [RequireComponent(typeof(SpriteRenderer), typeof(ClickableIndicatorBase))]
    public class WavePathToRandomTarget : MonoBehaviour, IClickable
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float frequency;
        [SerializeField] private float magnitude;
        [SerializeField] private bool spriteIsFacingRight;
        [SerializeField] private Transform[] targets;

        private bool isMoving;
        private bool hasFinishedMoving;

        private Vector2 startPos;
        private Vector2 endPos;
        private Vector2 dir;
        private float counter;
        private int index;

        private SpriteRenderer spriteRenderer;

        private void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

        private void Update()
        {
            if (isMoving)
            {
                counter += Time.deltaTime * frequency;

                // We use dir.x and dir.y here because when we go straight down we want to use the cosine
                // on the X-axis and vice versa. We put a minus in front of the Y-axis cosine because that works.
                Vector3 cos = new Vector3(Mathf.Cos(counter) * dir.y, -Mathf.Cos(counter) * dir.x, 0) * magnitude;
                Vector3 linear = dir * new Vector3(moveSpeed, moveSpeed, 0);

                // The cosine is only at (0, 0, 0) position so we have to add the linear transformation
                // to it. This way the cosine position is added at every position.
                transform.position += (cos + linear) * Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.transform == targets[index])
            {
                isMoving = false;
                hasFinishedMoving = true;

                // We don't need the indicator after we're done moving because
                // the bee can't move anymore. Can still be clicked on for sound effects etc.
                ClickableIndicatorBase indicator = GetComponent<ClickableIndicatorBase>();
                Destroy(indicator);
            }
        }

        public void ExecuteCustomBehaviour()
        {
            if (!hasFinishedMoving)
            {
                index = Random.Range(0, targets.Length);
                isMoving = true;
                startPos = transform.position;
                endPos = targets[index].position;
                dir = (endPos - startPos).normalized;
                counter = 0;

                if (dir.x < 0 && spriteIsFacingRight)
                {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    spriteIsFacingRight = !spriteIsFacingRight;
                }
                else if (dir.x > 0 && !spriteIsFacingRight)
                {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
                    spriteIsFacingRight = !spriteIsFacingRight;
                }
            }
        }
    }
}
