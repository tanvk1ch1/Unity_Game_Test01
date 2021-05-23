using System;

namespace ProjectS
{
    public interface IPhase
    {
        Action OnFinishPhase { get; set; }
        
        void Init(ControllData controllData);
        void Run(float deltatime);
    }
}