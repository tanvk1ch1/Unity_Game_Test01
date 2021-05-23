namespace ProjectS
{
    public class ScoreModel
    {
        #region Member
        
        private const int MaxScore = 99999;
        private int[] playerScore = {0, 0};
        
        #endregion
        
        #region Method
        
        public ScoreModel() {}
        
        public void AddPlayerScore(BallConstants.AttackPlayer player, int addScore)
        {
            playerScore[(int) player] += addScore;
            if (playerScore[(int) player] > MaxScore)
            {
                playerScore[(int) player] = MaxScore;
            }
        }
        
        public int GetPlayerScore(BallConstants.AttackPlayer player)
        {
            return playerScore[(int) player];
        }
        
        #endregion
    }
}