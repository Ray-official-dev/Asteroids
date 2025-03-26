using System;
using MPA.Utilits;

namespace Game.View
{
    public class CountdownTimer : IReadOnlyCountdownTimer, ITickable
    {
        public event Action TimerEnded;
        public float CurrentTime { get; private set; }
        public bool IsRunning { get; private set; } = false;

        public void Start(float duration)
        {
            IsRunning = true;
            CurrentTime = duration;
        }

        public void OnTick(float deltaTime)
        {
            if (!IsRunning) 
                return;

            CurrentTime -= deltaTime;

            if (CurrentTime <= 0)
            {
                CurrentTime = 0;
                IsRunning = false;
                TimerEnded?.Invoke();
            }
        }

        public string GetFormattedTime()
        {
            int minutes = (int)(CurrentTime / 60);
            int seconds = (int)(CurrentTime % 60);
            return string.Format("{0:0}:{1:00}", minutes, seconds);
        }
    }
}