using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    public class WavePathToObject : MonoBehaviour, IClickableCustomBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float frequency;
        [SerializeField] private float magnitude;
        [SerializeField] private bool spriteIsFacingRight;

        private ClickableItem thisItem;

        private bool isMoving;
        private bool hasFinishedMoving;

        private Vector2 startPos;
        private Vector2 endPos;
        private Vector2 dir;
        private float counter;

        private void Start()
        {
            thisItem = GetComponent<ClickableItem>();

            PathTarget[] targets = FindObjectsOfType<PathTarget>();

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].OnTargetClicked.AddListener(TargetClicked);
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                counter += Time.deltaTime * frequency;
                // We use dir.x and dir.y here because when we go straight down we want to use the cosine
                // on the X-axis and vice versa. We put a minus in front of the Y-axis cosine because that works.
                Vector3 cos = new Vector3(Mathf.Cos(counter) * dir.y, -Mathf.Cos(counter) * dir.x, 0) * magnitude;
                Vector3 linear = dir * new Vector3(moveSpeed, moveSpeed, 0);

                transform.position += (cos + linear) * Time.deltaTime;
            }
        }

        private void TargetClicked(Vector2 targetPos)
        {
            if (thisItem.IsSelected && !hasFinishedMoving)
            {
                isMoving = true;
                startPos = transform.position;
                endPos = targetPos;
                dir = (endPos - startPos).normalized;
                counter = 0;

                if (dir.x < 0 && spriteIsFacingRight)
                {
                    transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
                    spriteIsFacingRight = !spriteIsFacingRight;
                }
                else if (dir.x > 0 && !spriteIsFacingRight)
                {
                    transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
                    spriteIsFacingRight = !spriteIsFacingRight;
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PathTarget>())
            {
                isMoving = false;
                hasFinishedMoving = true;
            }
        }

        public void ExecuteCustomBehaviour()
        {
        }

        public void EndCustomBehaviour()
        {
        }
    }
}
