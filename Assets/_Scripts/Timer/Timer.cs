using System;

namespace ThuisBijMuis.Timers
{
    public class Timer
    {
        public float RemainingSeconds { get; private set; }

        public Timer(float duration)
        {
            RemainingSeconds = duration;
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

            RemainingSeconds = 0;

            OnTimerEnd?.Invoke();
        }
    }
}
