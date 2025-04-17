using System;
using MPA;
using UnityEngine;

namespace Utilits
{
    public class ViewTimer : View
    {
        public Action TimeEnded;
        private Timer _timer;

        public ViewTimer()
        {
            _timer = new Timer();
        }

        public override void OnTick()
        {
            _timer.Tick(Time.deltaTime);
        }

        public void StartTimer(float time)
        {
            _timer.Start(time);
        }

        public void ResetTimer()
        {
            _timer.Reset();
        }

        public void Pause()
        {
            _timer.Pause();
        }

        public void Resume()
        {
            _timer.Resume();
        }
    }
}
