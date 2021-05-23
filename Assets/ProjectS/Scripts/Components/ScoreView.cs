using UnityEngine;
using UnityEngine.UI;

namespace ProjectS
{
    public class ScoreView : MonoBehaviour
    {
        #region Member
        
        [SerializeField] private Text text;
        [SerializeField] private GameObject playerIcon;
        [SerializeField] private GameObject cpuIcon;
        
        #endregion
        
        #region Method

        public void SetScore(int score)
        {
            text.text = score.ToString();
        }
        
        public void SetCPUIcon()
        {
            playerIcon.SetActive(false);
            cpuIcon.SetActive(true);
        }
        
        #endregion
    }
}