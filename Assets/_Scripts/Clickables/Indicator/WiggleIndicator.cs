using ThuisBijMuis.Games.Interactables.CustomBehaviours;
using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.Indicators
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

        private Quaternion lastRotation;
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
                ClickableAnimation anim = item.GetComponentInChildren<ClickableAnimation>();
                anim?.OnAnimationEndedEvent.AddListener(UnPause);

                WiggleIndicator wi = item.AddComponent<WiggleIndicator>();
                wi.isAdder = false;
                wi.wiggleSpeed = wiggleSpeed;
                wi.wiggleStrength = wiggleStrength;
                wi.wiggleTime = wiggleTime;
                wi.wiggleTimeout = wiggleTimeout;
                wi.wiggleTimeoutVariation = wiggleTimeoutVariation;
                wi.lastRotation = wi.transform.localRotation;
                wi.Init();
            }
        }

        private void FixedUpdate()
        {
            if (isAdder || isPaused)
                return;

            if (!isWiggling)
            {
                // This means it's time for the wiggle. If we haven't waiting enough we keep
                // subtracting deltaTime from this number.
                if (nextWiggle <= 0)
                {
                    wiggledTime = 0;
                    nextWiggle = wiggleTimeout + Random.Range(0, wiggleTimeoutVariation);
                    isWiggling = true;
                }
                else
                    nextWiggle -= Time.deltaTime;

                // After wiggling our rotation might not be the same as before wiggling,
                // so if thats we case we lerp towards it.
                if (transform.localRotation != lastRotation)
                    transform.localRotation = Quaternion.Lerp(transform.localRotation, lastRotation, 0.33f);
            }

            // We check how long we have been wiggling for against the max time we can wiggle for.
            // If we exceed that amount we set isWiggling to false so we can enter the loop above again.
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
            // wiggledTime needs to be set to the wiggleTime or higher otherwise everthing 
            // would start wiggling on the first frame.
            wiggledTime = wiggleTime; 
            transform.localRotation = lastRotation;
        }
    }
}