using System;
using UnityEngine;

namespace ProjectS
{
    public class CountDownAnimation : MonoBehaviour
    {
        private Action _onEndCallBack;
        
        public void SetVisible(bool flag)
        {
            gameObject.SetActive(flag);
        }
        
        public void SetOnEndCallback(Action callback)
        {
            _onEndCallBack = callback;
        }
        
        // アニメーションのイベントで呼び出し
        public void OnEndCountdownAnimation()
        {
            _onEndCallBack?.Invoke();
            gameObject.SetActive(false);
        }
    }
}