using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ThuisBijMuis.Timers;
using System.Linq;

namespace ThuisBijMuis.Games.PageSliding {
#pragma warning disable 0649
    [RequireComponent(typeof(Canvas))]
    public class PageSlider : MonoBehaviour
    {
        [SerializeField]
        private float duration;

        private RectTransform canvas;
        private List<RectTransform> Panels = new List<RectTransform>();
        private float canvasWidth;
        private int frontPanelIndex = 0;
        private bool isCurrentlyLerping = false;

        public UnityBooleanEvent lerpEvent = new UnityBooleanEvent(); //The event that calls all the panels to lerp

        private List<IPageActivatable> pageObjects = new List<IPageActivatable>();
        private Timer timer;

        // Start is called before the first frame update
        void Start()
        {
            canvas = this.GetComponent<RectTransform>();

            canvasWidth = canvas.rect.width; //Canvas.width is always the width of the screen. The Canvas is set to stretch

            for (int i = 0; i < canvas.childCount; i++)
            {
                Panels.Add(canvas.GetChild(i) as RectTransform);
                Panels[i].anchoredPosition = new Vector2(canvasWidth * i, 0);
                Panels[i].gameObject.AddComponent<Panel>().Init(canvasWidth, duration);

                lerpEvent.AddListener(Panels[i].GetComponent<Panel>().SetLerpDirection);
            }

            pageObjects = InterfaceFinder.Find<IPageActivatable>();
        }

        private void Update() => timer?.Tick(Time.deltaTime);

        public void NextPageButton()
        {
            if (!isCurrentlyLerping) GoRight();
        }

        public void PreviousPageButton()
        {
            if (!isCurrentlyLerping) GoLeft();
        }


        /// <summary>
        /// Is called when the lerp of the panels had ended
        /// </summary>
        private void HandleTimerEnd()
        {
            isCurrentlyLerping = false;
            DisablePanels(frontPanelIndex);
            ActivatePageObjects();
        }

        private void ActivatePageObjects()
        {
            foreach (IPageActivatable Ipage in pageObjects)
            {
                Ipage.CheckPage(frontPanelIndex);
            }
        }

        /// <summary>
        /// Makes all the panels in Panels go left
        /// </summary>
        private void GoLeft()
        {
            if (frontPanelIndex > 0)
            {
                lerpEvent.Invoke(true);
                SetTimer(duration);
                frontPanelIndex--;
                EnablePanel(frontPanelIndex);
            }
        }

        /// <summary>
        /// Makes all the panels in Panels go right
        /// </summary>
        private void GoRight()
        {
            if (frontPanelIndex < Panels.Count - 1)
            {
                lerpEvent.Invoke(false);
                SetTimer(duration);
                frontPanelIndex++;
                EnablePanel(frontPanelIndex);
            }
        }

        /// <summary>
        /// Disables all the panels that are not the index
        /// </summary>
        /// <param name="indexOfPanel"></param>
        private void DisablePanels(int indexOfPanel)
        {
            for (int i = 0; i < Panels.Count; i++)
            {
                if (i != indexOfPanel) Panels[i].GetChild(0).gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// Enables only the panel with the index
        /// </summary>
        /// <param name="indexOfPanel"></param>
        private void EnablePanel(int indexOfPanel)
        {
            for (int i = 0; i < Panels.Count; i++)
            {
                if (i == indexOfPanel) Panels[i].GetChild(0).gameObject.SetActive(true);
            }
        }

        private void SetTimer(float duration)
        {
            timer = new Timer(duration);
            isCurrentlyLerping = true;
            timer.OnTimerEnd += HandleTimerEnd;
        }
    }

    public class UnityBooleanEvent : UnityEvent<bool> { }
    public class UntiyIntEvent : UnityEvent<int> { }
}