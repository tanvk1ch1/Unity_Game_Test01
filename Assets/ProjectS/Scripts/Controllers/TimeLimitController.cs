using System;
using UnityEngine;

namespace ProjectS
{
    public class TimeLimitController : MonoBehaviour
    {
        #region Member
        
        public Action onTimerEnd;
        
        private const float TimeLimitSeconds = 90;
        
        [SerializeField] private TimeLimitView _timeLimitView;
        
        private TimeLimitModel _model = new TimeLimitModel();
        private int limitTimeSe;
        
        #endregion
        
        #region MonoBehavior
        
        public void Init()
        {
            
        }
        
        #endregion
        
        #region Method
        
        public void TimeLimitUpdate(float deltaTime)
        {
            
        }
        
        private void SetTimer()
        {
            
        }
        
        private void TimerFinish()
        {
            
        }
        
        #endregion
    }
}