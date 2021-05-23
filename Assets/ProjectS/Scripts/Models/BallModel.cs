using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public class BallModel
    {
        #region Member
        
        public Action<Vector3> onSetMoveBall;
        public Action<BallConstants.AttackPlayer, int> onChangeAttackPlayer;
        public Action<BallConstants.AttackPlayer, int> onFinish;
        
        private ICPU CurrentCPU;
        
        private enum AttackKind
        {
            Lob,
            Normal,
            Smash,
            None
        }
        
        private Vector3 goalPos;
        private Vector3 startPos;
        private Vector3 halfPos;
        private float moveFrame;
        private float timer;
        private float height = 300.0f;
        
        private float vector;
        private int ballScore = BallConstants.AddScore;
        private int addScore = BallConstants.AddScore;
        
        private bool isStart;
        private AttackKind _attackKind;
        private Vector2 curentPos;
        private float moveRate;
        
        private bool isCPUMiss;
        private AttackKind cpuAttackKind = AttackKind.None;
        private float cpuNormalAttackDist;
        private bool isCPUFirstAttack;
        
        private GaugeModel _gaugeModel;
        
        public BallModel()
        {
            switch (GameDataStore.Instance.GameLevel)
            {
                case GameDataStore.Level.Level1:
                    CurrentCPU = new CPUEasy();
                    break;
                case GameDataStore.Level.Level2:
                    CurrentCPU = new CPUNormal();
                    break;
                case GameDataStore.Level.Level3:
                    CurrentCPU = new CPUHard();
                    break;
            }
        }
        
        #endregion
        
        #region Method
        
        public void Init(BallConstants.AttackPlayer attacker, ref GaugeModel model)
        {
            _gaugeModel = model;
        }
        
        private void CPUInit()
        {
            
        }
        
        public void Update(float deltatime)
        {
            
        }
        
        Vector3 CalcLerpPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            // TODO:演算
            return Vector3.Lerp(p1,p2, t);
        }
        
        public void SetHalfPos()
        {
            
        }
        
        public void Hit(int hit1, int hit2)
        {
            
        }
        
        public Color GetColorFromBallScore()
        {
            // 仮
            return Color.white;
        }

        private void SetAttackData(float dist)
        {
            
        }
        
        private AttackKind CheckAttackArea(float dist)
        {
            // TODO:打ち返す種類
            
            return AttackKind.Normal;
        }
        
        public float GetBallDistance()
        {
            // 仮の値
            float dist = 0.1f;
            return dist;
        }
        
        private void SetCPUAttackKind()
        {
            
        }
        
        public int CPUMove()
        {
            if (vector < 0 || curentPos.x < BallConstants.NotAttackArea || isCPUMiss)
            {
                return 0;
            }
            
            AttackKind attackKind = CheckAttackArea(GetBallDistance());
            
            if (cpuAttackKind != attackKind)
            {
                return 0;
            }
            
            if (attackKind == AttackKind.Normal && GetBallDistance() > cpuNormalAttackDist)
            {
                return 0;
            }
            
            if (isCPUFirstAttack)
            {
                isCPUFirstAttack = false;
                return 1;
            }
            
            AttackKind kind = AttackKind.Lob;
            int random = UnityEngine.Random.Range(0, 100);
            if (moveFrame == BallConstants.SmashSpeedFrame)
            {
                
            }
            
            isCPUMiss = true;
            return 0;
        }
        
        public BallConstants.AttackPlayer GetAttackPlayer()
        {
            return vector < 0 ? BallConstants.AttackPlayer.Player1 : BallConstants.AttackPlayer.Player2;
        }
        
        #endregion
        
    }
}