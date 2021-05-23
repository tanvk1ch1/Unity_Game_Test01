using System;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectS
{
    public class GaugeView : MonoBehaviour
    {
        #region Member
        
        private Slider _slider;
        
        #endregion
        
        #region Method
        
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }
        
        public void SetValue(float value)
        {
            _slider.value = value;
        }
        
        #endregion
    }
}