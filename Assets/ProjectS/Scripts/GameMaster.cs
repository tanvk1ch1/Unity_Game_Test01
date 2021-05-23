using System;
using UnityEngine;

namespace ProjectS
{
    public class GameMaster : BaseGameMaster
    {
        #region MyRegion
        
        [SerializeField]
        private ControllData controller;
        private IPhase _currentPhase;
        
        #endregion
        
        #region Method
        
        protected override void StartMain()
        {
            // 音
            SetStartPhase();
        }
        
        protected override void UpdateMain()
        {
            _currentPhase.Run(Time.deltaTime);
        }
        
        protected void OnDestroy()
        {
            base.OnDestroy();
            AssetLoader.Instance.Unload("Game");
        }
        
        void SetLoadPhase()
        {
            _currentPhase = new LoadPhase();
            _currentPhase.Init(controller);
            _currentPhase.OnFinishPhase = SetStartPhase;
        }
        
        void SetStartPhase()
        {
            _currentPhase = new StartPhase();
            _currentPhase.Init(controller);
            _currentPhase.OnFinishPhase = SetGamePhase;
        }
        
        void SetGamePhase()
        {
            _currentPhase = new GamePhase();
            _currentPhase.Init(controller);
            _currentPhase.OnFinishPhase = SetResultPhase;
        }
        
        void SetResultPhase()
        {
            _currentPhase = new ResultPhase();
            _currentPhase.Init(controller);
        }
        
        #endregion
        
    }
}