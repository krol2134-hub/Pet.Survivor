using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerUiView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        
        public void SetTime(float timer)
        {
            var minutes = Mathf.FloorToInt(timer / 60F);
            var seconds = Mathf.FloorToInt(timer - minutes * 60);
            var niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            _timerText.text = niceTime;
        }
    }
}
