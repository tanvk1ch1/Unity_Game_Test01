using System;
using UnityEngine;

namespace ProjectS
{
    public class ResultPhase : IPhase
    {
        public Action OnFinishPhase { get; set; }
        private ControllData _controllData;
        
        public void Init(ControllData data)
        {
            _controllData = data;
            
            _controllData.ResultControllerFinishAnimationEndCallback(CheckJudge);
            _controllData.ResultControllerEndCallback(() => {OnFinishPhase?.Invoke(); });
            _controllData.ResultControllerInit();
        }
        
        public void Run(float deltaTime)
        {
            
        }
        
        public void CheckJudge()
        {
            // 得点の保存
            GameDataStore.Instance.PlayerScore[0] =
                _controllData.ScoreControllerGetPlayerScore(BallConstants.AttackPlayer.Player1);
            GameDataStore.Instance.PlayerScore[1] =
                _controllData.ScoreControllerGetPlayerScore(BallConstants.AttackPlayer.Player2);
            
            // 判定の保持
            GameDataStore.MinigameJudge judge;
            if (GameDataStore.Instance.PlayerScore[0] > GameDataStore.Instance.PlayerScore[1])
            {
                judge = GameDataStore.MinigameJudge.P1Win;
            }
            else if (GameDataStore.Instance.PlayerScore[0] == GameDataStore.Instance.PlayerScore[1])
            {
                judge = GameDataStore.MinigameJudge.Draw;
            }
            else
            {
                if (GameDataStore.Instance.PlayerNum > 1)
                {
                    judge = GameDataStore.MinigameJudge.P2Win;
                }
                else
                {
                    judge = GameDataStore.MinigameJudge.CPUWin;
                }
            }
            // 勝敗を記録させたい時に使いたい
            //GameDataStore.Instance.SetPlayerJudge(judge);
        }
    }
}