using UnityEngine;

namespace ProjectS
{
    public class LoadDataObserver : MonoBehaviour
    {
        public LoadDataObserver() {}
        
        public GameObject GetEnemyGameObject(int no)
        {
            string[] str = {"GameEnemyRed", "GameEnemyBlue"};
            return ResourceStore.Instance.Get<GameObject>(str[no]);
        }
        
        public GameObject GetStageGameObject()
        {
            return ResourceStore.Instance.Get<GameObject>("Stage");
        }
        
        public GameObject GetStartCount()
        {
            return ResourceStore.Instance.Get<GameObject>("StartCount");
        }
        
        public GameObject GetGameFinish()
        {
            return ResourceStore.Instance.Get<GameObject>("GameFinish");
        }
        
        public GameObject GetGameResult()
        {
            return ResourceStore.Instance.Get<GameObject>("GameResultAnimaton");
        }
        
        public GameObject GetEffectObject()
        {
            // TODO:エフェクト
            return ResourceStore.Instance.Get<GameObject>("Effect");
        }
    }
}