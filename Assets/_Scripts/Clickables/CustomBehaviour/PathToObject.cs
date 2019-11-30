using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    public class PathToObject : MonoBehaviour, IClickableCustomBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float frequency;
        [SerializeField] private float magnitude;

        private ClickableItem thisItem;

        private bool isMoving;

        private Vector2 startPos;
        private Vector2 endPos;
        private Vector2 dir;
        private Vector2 perpDir;

        private void Start()
        {
            thisItem = GetComponent<ClickableItem>();
            startPos = transform.position;
            dir = endPos - startPos;

            PathObject[] targets = FindObjectsOfType<PathObject>();

            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].OnTargetClicked.AddListener(TargetClicked);
            }
        }

        private void Update()
        {
            if (isMoving)
            {
                transform.position = startPos + perpDir * Mathf.Sin(Time.time * frequency) * magnitude;
                transform.Translate(dir * moveSpeed * Time.deltaTime);
            }
        }

        private void TargetClicked(Vector2 pos)
        {
            if (thisItem.IsSelected)
            {
                isMoving = true;
                endPos = pos;
                dir = (endPos - startPos).normalized;
                perpDir = new Vector2(-dir.x, dir.y);

                Debug.DrawLine(startPos, endPos-startPos, Color.red, 10f);
                Debug.DrawLine(startPos, startPos + perpDir, Color.blue, 10f);
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
