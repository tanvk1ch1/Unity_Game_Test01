using UnityEngine;

namespace ProjectS
{
    public class TimeUtility
    {
        public static float UnscaledDeltaTime
        {
            get
            {
                float unscaledDeltaTime = Time.unscaledDeltaTime;

                if (unscaledDeltaTime >= 0.1f) return 1f / 60f;
                return unscaledDeltaTime;
            }
        }
    }
}