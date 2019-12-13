using System;

namespace ThuisBijMuis.Timers
{
    public class Timer
    {
        public float RemainingSeconds { get; private set; }
        private float originalSeconds;
        private bool repeating;

        public Timer(float duration, bool repeating = false)
        {
            RemainingSeconds = duration;
            originalSeconds = RemainingSeconds;
            this.repeating = repeating;
        }

        /// <summary>
        /// Calls this event when the timer had ended
        /// </summary>
        public event Action OnTimerEnd;

        /// <summary>
        /// Ticks the Timer, call this every update
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Tick(float deltaTime)
        {
            if (RemainingSeconds == 0) return;

            RemainingSeconds -= deltaTime;

            CheckForTimerEnd();
        }

        private void CheckForTimerEnd()
        {
            if (RemainingSeconds > 0) return;

            if (!repeating) RemainingSeconds = 0;
            else RemainingSeconds = originalSeconds;

            OnTimerEnd?.Invoke();
        }
    }
}
