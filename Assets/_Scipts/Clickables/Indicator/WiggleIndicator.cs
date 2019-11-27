using UnityEngine;

namespace ThuisBijMuis.Clickables.Indicators
{
#pragma warning disable 0649
    public class WiggleIndicator : ClickableIndicatorBase
    {
        [SerializeField] private bool isAdder;
        [SerializeField] private float wiggleSpeed;
        [SerializeField, Tooltip("How many degrees does it rotate?")] private float wiggleStrength;
        [SerializeField, Tooltip("How long does it wiggle?")] private float wiggleTime;
        [SerializeField, Tooltip("How long between wiggles?")] private float wiggleTimeout;
        [SerializeField] private float wiggleTimeoutVariation;

        private float nextWiggle;
        private float wiggledTime;
        private bool isWiggling;

        protected override void Awake()
        {
            if (!isAdder)
                return;

            base.Awake();

            for (int i = 0; i < clickableItems.Length; i++)
            {
                GameObject item = clickableItems[i].gameObject;
                WiggleIndicator wi = item.AddComponent<WiggleIndicator>();
                wi.isAdder = false;
                wi.wiggleSpeed = wiggleSpeed;
                wi.wiggleStrength = wiggleStrength;
                wi.wiggleTime = wiggleTime;
                wi.wiggleTimeout = wiggleTimeout;
                wi.wiggleTimeoutVariation = wiggleTimeoutVariation;
                wi.Init();
            }
        }

        private void FixedUpdate()
        {
            if (isAdder || isPaused)
                return;

            if (!isWiggling)
            {
                if (nextWiggle <= 0)
                {
                    wiggledTime = 0;
                    nextWiggle = wiggleTimeout + Random.Range(0, wiggleTimeoutVariation);
                    isWiggling = true;
                }
                else
                    nextWiggle -= Time.deltaTime;

                if (transform.localRotation != Quaternion.identity)
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.identity, 0.33f);
            }

            if (wiggledTime < wiggleTime)
            {
                transform.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleStrength);
                wiggledTime += Time.deltaTime;
            }
            else
                isWiggling = false;
        }

        protected override void Init()
        {
            nextWiggle = wiggleTimeout + Random.Range(0, wiggleTimeoutVariation);
            wiggledTime = wiggleTime;
            transform.localRotation = Quaternion.identity;
        }
    }
}