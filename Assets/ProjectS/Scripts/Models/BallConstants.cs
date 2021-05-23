using UnityEngine;

namespace ProjectS
{
    public static class BallConstants
    {
        #region Member
        
        public enum AttackPlayer
        {
            Player1 = 0,
            Player2,
            None
        }
        
        //TODO:位置や打ち返し不能な位置、スコアや速度を定義
        
        public const float StartPosX = 400;
        public const float StartPosY = 150;
        public const float GoalPosX = 620;
        public const float GoalPosY = -230;
        
        public const float NotAttackArea = 150; // 打ち返せないエリア
        
        public const float SmashSpeedFrame = 80;
        public const float NormalSpeedFrame = 130;
        public const float LobSpeedFrame = 180;
        
        public const int AddScore = 20;
        public const int AddSmashScore = 30;
        public const int AddLobScore = 10;
        
        #endregion

    }
}