using System;

namespace Utilits
{
    public class Timer
    {
        public event Action TimeEnded;

        private float _currentTime;
        private float _targetTime;
        private bool _isRunning;

        public void Start(float time)
        {
            _targetTime = time;
            _currentTime = 0f;
            _isRunning = true;
        }

        public void Tick(float deltaTime)
        {
            if (!_isRunning) return;

            _currentTime += deltaTime;

            if (_currentTime >= _targetTime)
            {
                FinishTimer();
            }
        }

        public void Pause()
        {
            _isRunning = false;
        }

        public void Resume()
        {
            _isRunning = true;
        }

        public void Reset()
        {
            _currentTime = 0f;
            _isRunning = false;
        }

        private void FinishTimer()
        {
            _isRunning = false;
            TimeEnded?.Invoke();
        }

        public float RemainingTime => Math.Max(_targetTime - _currentTime, 0f);
        public float Progress => Math.Clamp(_currentTime / _targetTime, 0f, 1f);
        public bool IsRunning => _isRunning;
    }
}
