using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThuisBijMuis.Games.PageSliding
{
#pragma warning disable 0649
    public class Panel : MonoBehaviour
    {
        private float time;
        private RectTransform rectTransform;
        private Vector2 currentPosition;
        private Vector2 targetPositionLeft, targetPositionRight;
        private float duration;
        private float moveAmount;
        private bool canLerp;
        private bool lerpDirection;

        public void Init(float moveAmount, float duration)
        {
            rectTransform = GetComponent<RectTransform>();
            currentPosition = rectTransform.anchoredPosition;
            SetTargetPositions(moveAmount);
            this.duration = duration;
            this.moveAmount = moveAmount;
        }

        /// <summary>
        /// Sets the target position relative to the start position
        /// </summary>
        /// <param name="moveAmount"></param>
        private void SetTargetPositions(float moveAmount)
        {
            currentPosition = rectTransform.anchoredPosition;
            targetPositionLeft = currentPosition + new Vector2(moveAmount, 0);
            targetPositionRight = currentPosition - new Vector2(moveAmount, 0);
        }

        private void Update()
        {
            if (canLerp) LerpPanel(lerpDirection);
        }

        /// <summary>
        /// Sets the lerp direction. This is called by the event in PageSlider
        /// </summary>
        /// <param name="left"></param>
        public void SetLerpDirection(bool left)
        {
            canLerp = true;
            lerpDirection = left;
        }


        private bool LerpPanel(bool left)
        {
            if (time < 1)
            {
                time += Time.deltaTime / duration;
                if (left) rectTransform.anchoredPosition = Vector2.Lerp(currentPosition, targetPositionLeft, time);
                else rectTransform.anchoredPosition = Vector2.Lerp(currentPosition, targetPositionRight, time);
                return false;
            }
            else
            {
                time = 0;
                SetTargetPositions(moveAmount);
                canLerp = false;
                return true;
            }
        }
    }
}
