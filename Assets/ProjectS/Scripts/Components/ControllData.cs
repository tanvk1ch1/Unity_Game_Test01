using System;
using UnityEngine;

namespace ProjectS
{
    public class ControllData : MonoBehaviour
    {
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
        
        private LoadData _loadData;
        
        private void Awake()
        {
            _loadData = new LoadData();
        }

        public void StartCountDownAnimation(Action endcallback)
        {
            if (_countDownAnimation == null)
            {
                GameObject obj = Instantiate(_loadData.GetStartCount());
                _countDownAnimation = obj.GetComponent<CountDownAnimation>();
            }
            _countDownAnimation.SetOnEndCallback(endcallback);
            _countDownAnimation.SetVisible(true);
        }
        
        public void StopCountDownAnimation()
        {
            _countDownAnimation.SetVisible(false);
        }

        public void BallControllerInit()
        {
            _ballController.Init()
        }
    }
}