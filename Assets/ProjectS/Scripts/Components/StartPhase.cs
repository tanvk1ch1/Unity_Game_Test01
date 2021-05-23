using System;
using UnityEngine;

namespace ProjectS
{
    public class StartPhase : IPhase
    {
        #region Member
        
        public Action OnFinishPhase { get; set; }
        private ControllData _controllData;
        private GameObject readyObject;
        
        #endregion
        
        #region Method
        
        public void Init(ControllData data)
        {
            _controllData = data;
            
            // Readyオブジェクトを作る
            if (readyObject == null)
            {
                readyObject = MonoBehaviour.Instantiate(ResourceStore.Instance.Get<GameObject>("ReadyCanvas"));
                readyObject.SetActive(false);
            }
            
            // ステージを作る
            SetStage();
            
            _controllData.PlayerControllerInit();
            _controllData.BallControllerGaugeInit();
            _controllData.TimeLimitControllerInit();
            
            FadeManager.Instance.FadeIn(OnFinishFadeIn);
        }
        
        public void Run(float deltaTime)
        {
            if (readyObject == null || !readyObject.activeSelf)
            {
                return;
            }
            if (InputObserver.Instance.CheckKeyDownDecide())
            {
                readyObject.SetActive(false);
                _controllData.StartCountDownAnimation(OnEndCountDown);
            }
        }
        
        private void OnFinishFadeIn()
        {
            readyObject.SetActive(true);
        }
        
        private void OnEndCountDown()
        {
            OnFinishPhase?.Invoke();
        }
        
        private void SetStage()
        {
            GameObject stage = MonoBehaviour.Instantiate(_controllData.GetLoadData().GetStageGameObject());
        }
        
        #endregion
    }
}