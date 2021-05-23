using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public class PlayerController : MonoBehaviour
    {
        #region Member
        
        private List<Animator> _animators = new List<Animator>();
        private LoadDataObserver _loadDataObserver;
        
        #endregion
        
        #region MonoBehavior
        
        public void Init(LoadDataObserver load)
        {
            _loadDataObserver = load;
            SetEnemyObject();
        }
        
        #endregion
        
        #region Method
        
        private void SetEnemyObject()
        {
            
        }
        
        public void StartAttackAnimation(BallConstants.AttackPlayer player)
        {
            
        }
        
        #endregion
    }
}