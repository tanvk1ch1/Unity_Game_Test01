using System;

namespace ProjectS
{
    public class TimeLimitModel
    {
        #region Member
        
        public Action onFinishTimer;
        
        private float timeLimitSeconds;
        private float timer;
        
        public TimeLimitModel() {}
        
        #endregion
        
        #region Method
        
        public void SetTimeLimit(float max)
        {
            timeLimitSeconds = max;
        }
        
        public void Update(float deltaTime)
        {
            timer += deltaTime;
            if (timer >= timeLimitSeconds)
            {
                onFinishTimer?.Invoke();
            }
        }
        
        public int GetRestTime()
        {
            float rest = timeLimitSeconds - timer;
            if (rest > 0 && rest < timeLimitSeconds)
            {
                return (int)rest + 1;
            }
            return (int)rest;
        }
        
        #endregion
    }
}