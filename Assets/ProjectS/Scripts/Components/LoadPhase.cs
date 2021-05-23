using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectS
{
    public class LoadPhase : IPhase
    {
        public Action OnFinishPhase { get; set; }
        private ControllData _controllData;
        private Task<IList<UnityEngine.Object>> loadTask;
        
        public void Init(ControllData data)
        {
            _controllData = data;
            loadTask = AssetLoader.Instance.Load<UnityEngine.Object>("Game");
        }
        
        public void Run(float deltatime)
        {
            if (loadTask.IsCompleted) OnEndLoad();
        }
        
        private void OnEndLoad()
        {
            OnFinishPhase?.Invoke();
        }
    }
}