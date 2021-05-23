using System;
using UnityEngine;

namespace ProjectS
{
    public class GamePhase : IPhase
    {
        public Action OnFinishPhase { get; set; }
        
        private ControllData _controllData;
        private BallConstants.AttackPlayer _attackPlayer = BallConstants.AttackPlayer.Player1;
        
        public void Init(ControllData data)
        {
            if (_controllData == null) _controllData = data;
            
            _controllData.BallControllerInit(_attackPlayer, WaveFinish, OnChangeAttackPlayer);
            _controllData.TimeLimitControllerEndCallback(PhaseFinish);
        }
        
        public void Run(float deltatime)
        {
            int hit1, hit2;
            
            // TODO:要検討
            hit1 = InputObserver.Instance.HitDown;
            
            if (GameDataStore.Instance.PlayerNum > 1)
            {
                hit2 = InputObserver.Instance.HitDown;
            }
            else
            {
                hit2 = _controllData.BallControllerCPUMove();
            }
            
            // 打ち返し判定処理
            _controllData.BallControllerHit(hit1, hit2);
            // ボールの動作
            _controllData.BallControllerUpdate(deltatime);
            // 制限時間
            _controllData.TimeLimitControllerUpdate(deltatime);
        }
        
        private void OnChangeAttackPlayer(BallConstants.AttackPlayer attacker)
        {
            // 打ち返すアニメーション動作
            _controllData.PlayerControllerAttackAnimation(_attackPlayer);
            // 次に打つプレイヤーに変更
            _attackPlayer = attacker;
        }
        
        public void WaveFinish(BallConstants.AttackPlayer winPlayer, int addScore)
        {
            // スコアの加算
            _controllData.ScoreControllerSetPlayerScore(winPlayer, addScore);
            // 次に打つ側を設定
            _attackPlayer = winPlayer;
            // 次のWave
            Init(null);
        }
        
        private void PhaseFinish()
        {
            OnFinishPhase?.Invoke();
        }
    }
}