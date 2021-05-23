namespace ProjectS
{
    public class GaugeModel
    {
        #region Method
        
        public GaugeModel() {}
        
        public float GetGaugeValue(float distance)
        {
            float per = 0;
            float goalDistance = BallConstants.GoalPosX - BallConstants.NotAttackArea;
            // 引数からボールとの距離によってゲージ設定を行う
            if (distance < goalDistance && distance >= goalDistance / 2)
            {
                // 上がる
                per = (goalDistance - distance) / (goalDistance / 2);
            }
            else if (distance < goalDistance && distance < goalDistance / 2)
            {
                per = distance / (goalDistance / 2);
            }
            
            return 100;
        }
        #endregion
        
    }
}