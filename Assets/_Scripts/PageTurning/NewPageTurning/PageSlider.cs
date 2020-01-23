using System.Collections.Generic;
using ThuisBijMuis.Games.Interactables;
using ThuisBijMuis.Swiping;
using ThuisBijMuis.Timers;
using UnityEngine;
using UnityEngine.Events;

namespace ThuisBijMuis.Games.PageSliding
{
#pragma warning disable 0649
    [RequireComponent(typeof(Canvas))]
    public class PageSlider : MonoBehaviour
    {
        [SerializeField] private float duration;
        [SerializeField] private bool reactsToSwipe;

        private RectTransform canvas;
        private List<RectTransform> Panels = new List<RectTransform>();
        private float canvasWidth;
        private int frontPanelIndex;
        private bool isCurrentlyLerping;

        private List<IPageActivatable> pageObjects = new List<IPageActivatable>();
        private Timer timer;

        // The event that calls all the panels to lerp.
        public UnityBooleanEvent lerpEvent = new UnityBooleanEvent();
        public UnityEvent OnPageSlideEnd;

        private void Awake() => SwipeDetector.OnSwipe += OnSwipe;

        void Start()
        {
            // Canvas.width is always the width of the screen and the Canvas is set to stretch.
            canvas = GetComponent<RectTransform>();
            canvasWidth = canvas.rect.width;

            for (int i = 0; i < canvas.childCount; i++)
            {
                Panels.Add(canvas.GetChild(i) as RectTransform);
                Panels[i].anchoredPosition = new Vector2(canvasWidth * i, 0);
                Panels[i].gameObject.AddComponent<Panel>().Init(canvasWidth, duration);

                lerpEvent.AddListener(Panels[i].GetComponent<Panel>().SetLerpDirection);
            }

            pageObjects = InterfaceFinder.Find<IPageActivatable>();

            ActivatePageObjects();
        }

        private void Update() => timer?.Tick(Time.deltaTime);

        private void OnSwipe(SwipeData data)
        {
            if (reactsToSwipe && !InputHandler.Singleton.Selection)
            {
                if (data.Direction == SwipeDirection.Right) NextPageButton();
                if (data.Direction == SwipeDirection.Left) PreviousPageButton();
            }
        }

        public void NextPageButton()
        {
            if (!isCurrentlyLerping) GoRight();
        }

        public void PreviousPageButton()
        {
            if (!isCurrentlyLerping) GoLeft();
        }

        /// <summary>
        /// Is called when the lerp of the panels had ended.
        /// </summary>
        private void HandleTimerEnd()
        {
            isCurrentlyLerping = false;
            //DisablePanels(frontPanelIndex);
            ActivatePageObjects();
            OnPageSlideEnd?.Invoke();
        }

        private void ActivatePageObjects()
        {
            foreach (IPageActivatable Ipage in pageObjects) Ipage.CheckPage(frontPanelIndex);
        }

        /// <summary>
        /// Makes all the panels in Panels go left.
        /// </summary>
        private void GoLeft()
        {
            if (frontPanelIndex > 0)
            {
                lerpEvent.Invoke(true);
                SetTimer(duration);
                frontPanelIndex--;
                //EnablePanel(frontPanelIndex);
            }
        }

        /// <summary>
        /// Makes all the panels in Panels go right.
        /// </summary>
        private void GoRight()
        {
            if (frontPanelIndex < Panels.Count - 1)
            {
                lerpEvent.Invoke(false);
                SetTimer(duration);
                frontPanelIndex++;
                //EnablePanel(frontPanelIndex);
            }
        }

        /// <summary>
        /// Disables all the panels that are not the index.
        /// </summary>
        /// <param name="indexOfPanel"></param>
        private void DisablePanels(int indexOfPanel)
        {
            for (int i = 0; i < Panels.Count; i++)
                if (i != indexOfPanel) Panels[i].GetChild(2).gameObject.SetActive(false);
        }

        /// <summary>
        /// Enables only the panel with the index.
        /// </summary>
        /// <param name="indexOfPanel"></param>
        private void EnablePanel(int indexOfPanel)
        {
            for (int i = 0; i < Panels.Count; i++)
                if (i == indexOfPanel) Panels[i].GetChild(2).gameObject.SetActive(true);
        }

        private void SetTimer(float duration)
        {
            timer = new Timer(duration);
            isCurrentlyLerping = true;
            timer.OnTimerEnd += HandleTimerEnd;
        }
    }

    public class UnityBooleanEvent : UnityEvent<bool> { }
}