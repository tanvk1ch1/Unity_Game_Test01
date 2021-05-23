using System.Collections.Generic;

namespace ProjectS
{
    public class GameDataStore
    {
        public enum MinigameJudge
        {
            None = 0,
            P1Win,
            P2Win,
            CPUWin,
            Draw
        }
        
        public enum Level
        {
            Level1 = 0,
            Level2,
            Level3
        }
        
        public static GameDataStore Instance { get; } = new GameDataStore();
        public int PlayerNum = 1;
        public float[] PlayerScore = new float[2];
        public Level GameLevel = Level.Level2;
        private List<string> assetBundleLabel = new List<string>();
        
        public string AssetBundleLabel
        {
            set => assetBundleLabel.Add(value);
            get
            {
                return assetBundleLabel[0];
            }
        }
        
        public string NextSceneName = "";
    }
}