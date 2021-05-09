using UnityEngine;

namespace ProjectS
{
    public class GameMaster : MonoBehaviour
    {
        [SerializeField]
        private ControllData controller;
        private IPhase _currentPhase;
        
        void SetLoadPhase()
        {
            _currentPhase = new LoadPhase();
            _currentPhase.Init();
            _currentPhase.OnFinishPhase = SetStartPhase;
        }
        
        void SetStartPhase()
        {
            _currentPhase = new StartPhase();
            _currentPhase.Init();
            _currentPhase.OnFinishPhase = setGamePhase;
        }
        
        void SetGamePhase()
        {
            _currentPhase = new GamePhase();
            _currentPhase.Init();
            _currentPhase.OnFinishPhase = setResultPhase;
        }
        
        void SetResultPhase()
        {
            _currentPhase = new ResultPhase();
            _currentPhase.Init();
        }
    }
}