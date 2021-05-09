using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public class LoadPhase : IPhase
    {
        public Action OnFinishPhase { get; set; }
        
        
        public void Init()
        {
            
        }
        
        public void Run()
        {
            
        }
        
        private void OnEndLoad()
        {
            OnFinishPhase?.Invoke();
        }
    }
}