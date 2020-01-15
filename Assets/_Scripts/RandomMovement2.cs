using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThuisBijMuis.Timers;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours {
#pragma warning disable 0649
    public class RandomMovement2 : MonoBehaviour, IClickable
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
        private Timer timer;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            timer = new Timer(5, true);
            timer.OnTimerEnd += DoTheMove;
        }

        private void Update()
        {
            timer.Tick(Time.deltaTime);

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

        void DoTheMove()
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

        public void ExecuteCustomBehaviour()
        {
            isMoving = false;
            hasFinishedMoving = true;
        }
    }
}

