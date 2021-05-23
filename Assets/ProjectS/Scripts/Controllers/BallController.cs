using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public class BallController : MonoBehaviour
    {
        private const float SliderValueMin = 100;
        
        public Action<BallConstants.AttackPlayer, int> onEndWave;
        public Action<BallConstants.AttackPlayer> onSetAttackPlayer;
        
        [SerializeField]
        private BallView _ballView;
        [SerializeField]
        private List<GaugeView> gaugeSlider = new List<GaugeView>();
        private BallModel _model = new BallModel();
        private GaugeModel _gaugeModel = new GaugeModel();
        private GameObject _burstPrefab;
        
        public void Init(BallConstants.AttackPlayer player, Action<BallConstants.AttackPlayer, int> callback,
            Action<BallConstants.AttackPlayer> setAttackPlayer, GameObject effectPrefab)
        {
            onEndWave = callback;
            onSetAttackPlayer = setAttackPlayer;
            _model.onSetMoveBall = OnSetBallPosition;
            _model.onChangeAttackPlayer = OnChangeAttackPlayer;
            _model.onFinish = OnFinishWave;
            _model.Init(player, ref _gaugeModel);
            
            // TODO:エフェクトのPrefab
            // Prefab = Prefab;
            
            _ballView.SetColor(_model.GetColorFromBallScore());
            
            GaugeInit();
        }

        public void BallUpdate(float deltatime)
        {
            _model.Update(deltatime);
            GaugeUpdate();
        }
        
        public void GaugeInit()
        {
            foreach (GaugeView slider in gaugeSlider)
            {
                slider.SetValue(SliderValueMin);
            }
        }
        
        public void GaugeUpdate()
        {
            gaugeSlider[(int)_model.GetAttackPlayer()].SetValue(_gaugeModel.GetGaugeValue(GetBallDistance()));
        }
        
        public int CPUMove()
        {
            return _model.CPUMove();
        }
        
        private void OnSetBallPosition(Vector3 pos)
        {
            _ballView.SetPosition(pos);
        }
        
        private void OnFinishWave(BallConstants.AttackPlayer player, int addScore)
        {
            
        }
        
        IEnumerator StartEffectAnimation(BallConstants.AttackPlayer player, int addScore)
        {
            yield break;
        }
        
        public void BallHit(int hit1, int hit2)
        {
            _model.Hit(hit1, hit2);
        }
        
        public void OnChangeAttackPlayer(BallConstants.AttackPlayer player, int addScore, Color color)
        {
            onSetAttackPlayer?.Invoke(player);
            
            _ballView.SetPoint(addScore);
            _ballView.StartAnimation();
            _ballView.SetColor(color);
        }
        
        public float GetBallDistance()
        {
            return _model.GetBallDistance();
        }
    }
}