using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectS
{
    public interface IPhase
    {
        Action OnFinishPhase { get; set; }
        
        void Init();
        void Run();
    }
}