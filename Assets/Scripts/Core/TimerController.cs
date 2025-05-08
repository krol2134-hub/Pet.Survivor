using Core.UpdateServices;
using UI;
using UnityEngine;

namespace Core
{
    public class TimerController : IUpdatable
    {
        private readonly TimerView _timerView;

        private float _startTime;

        public TimerController(TimerView timerView)
        {
            _timerView = timerView;

            _startTime = Time.time;
        }

        public void Update()
        {
            var timer = Time.time - _startTime;
            
            _timerView.SetTime(timer);
        }
    }
}