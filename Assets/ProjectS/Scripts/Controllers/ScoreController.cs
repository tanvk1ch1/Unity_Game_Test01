using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public class ScoreController : MonoBehaviour
    {
        #region Member
        
        [SerializeField] private List<ScoreView> _scoreView = new List<ScoreView>();
        
        private ScoreModel _model = new ScoreModel();
        
        #endregion
        
        #region MonoBehavior
        
        void Awake()
        {
            foreach (ScoreView view in _scoreView)
            {
                view.SetScore(0);
            }
            if (GameDataStore.Instance.PlayerNum == 1)
            {
                _scoreView[1].SetCPUIcon();
            }
        }
        
        #endregion
        
        #region Method
        
        public void SetPlayerScore(BallConstants.AttackPlayer player, int score)
        {
            _model.AddPlayerScore(player, score);
            
            // viewの更新
            _scoreView[(int)player].SetScore(_model.GetPlayerScore(player));
        }
        
        public int GetPlayerScore(BallConstants.AttackPlayer player)
        {
            return _model.GetPlayerScore(player);
        }
        
        #endregion
    }
}