using Core.UpdateServices;
using UI;
using UnityEngine;

namespace Core
{
    public class TimerController : IUpdatable
    {
        private readonly TimerUiView _timerUiView;

        private float _startTime;

        public TimerController(TimerUiView timerUiView)
        {
            _timerUiView = timerUiView;

            _startTime = Time.time;
        }

        public void Update()
        {
            var timer = Time.time - _startTime;
            
            _timerUiView.SetTime(timer);
        }
    }
}