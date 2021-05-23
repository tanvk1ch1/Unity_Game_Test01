using System;
using UnityEngine;

namespace ProjectS
{
    public class ResultController : MonoBehaviour
    {
        #region Member
        
        public Action onFinishAnimationEnd;
        public Action onEndCallback;
        
        private AnimationEvent finishAnimation;
        private AnimationEvent resultAnimation;
        private Animator resultAnimator;
        
        #endregion
        
        #region MonoBehavior
        
        public void Init(GameObject parent, LoadDataObserver loadDataObserver)
        {
            
        }
        
        #endregion
        
        #region Method
        
        private void OnAnimationEnd(GameObject gameObject)
        {
            
        }
        
        private void OnFinishFadeOut()
        {
            onEndCallback?.Invoke();
        }
        
        #endregion
    }
}