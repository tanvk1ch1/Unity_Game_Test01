using System;
using UnityEngine;

namespace ProjectS
{
    public class ControllData : MonoBehaviour
    {
        [SerializeField]
        private GameObject _canvasParent;
        private CountDownAnimation _countDownAnimation;
        
        [SerializeField]
        private PlayerController _playerController;
        [SerializeField]
        private ScoreController _scoreController;
        [SerializeField]
        private BallController _ballController;
        [SerializeField]
        private TimeLimitController _timeLimitController;
        [SerializeField]
        private ResultController _resultContoller;
        
        private LoadDataObserver _loadData;
        
        private void Awake()
        {
            _loadData = new LoadDataObserver();
        }
        
        public void IInputControllerGetHit()
        {
            
        }
        
        public void StartCountDownAnimation(Action endCallback)
        {
            if (_countDownAnimation == null)
            {
                GameObject obj = Instantiate(_loadData.GetStartCount());
                _countDownAnimation = obj.GetComponent<CountDownAnimation>();
            }
            _countDownAnimation.SetOnEndCallback(endCallback);
            _countDownAnimation.SetVisible(true);
        }
        
        public void StopCountDownAnimation()
        {
            _countDownAnimation.SetVisible(false);
        }
        
        public void BallControllerInit(BallConstants.AttackPlayer player, Action<BallConstants.AttackPlayer,int> callback, Action<BallConstants.AttackPlayer> setAttackPlayer)
        {
            // TODO:エフェクト
            _ballController.Init(player, callback, setAttackPlayer, _loadData.GetEffectObject());
        }
        
        public void BallControllerUpdate(float deltatime)
        {
            _ballController.BallUpdate(deltatime);
        }
        
        public void BallControllerHit(int hit1, int hit2)
        {
            _ballController.BallHit(hit1, hit2);
        }
        
        public float BallControlGetBallDistance()
        {
            return _ballController.GetBallDistance();
        }
        
        public int BallControllerCPUMove()
        {
            return _ballController.CPUMove();
        }
        
        public void BallControllerGaugeInit()
        {
            _ballController.GaugeInit();
        }
        
        public void PlayerControllerInit()
        {
            _playerController.Init(_loadData);
        }
        
        public void PlayerControllerAttackAnimation(BallConstants.AttackPlayer player)
        {
            _playerController.StartAttackAnimation(player);
        }
        
        public void ScoreControllerSetPlayerScore(BallConstants.AttackPlayer player, int addScore)
        {
            _scoreController.SetPlayerScore(player, addScore);
        }
        
        public int ScoreControllerGetPlayerScore(BallConstants.AttackPlayer player)
        {
            return _scoreController.GetPlayerScore(player);
        }
        
        public void TimeLimitControllerInit()
        {
            _timeLimitController.Init();
        }
        
        public void TimeLimitControllerUpdate(float deltatime)
        {
            _timeLimitController.TimeLimitUpdate(deltatime);
        }
        
        public void TimeLimitControllerEndCallback(Action callback)
        {
            _timeLimitController.onTimerEnd = callback;
        }
        
        public void ResultControllerInit()
        {
            _resultContoller.Init(_canvasParent, _loadData);
        }
        
        public void ResultControllerEndCallback(Action callback)
        {
            _resultContoller.onEndCallback = callback;
        }
        
        public void ResultControllerFinishAnimationEndCallback(Action callback)
        {
            _resultContoller.onFinishAnimationEnd = callback;
        }
        
        public LoadDataObserver GetLoadData()
        {
            return _loadData;
        }
    }
}