namespace ProjectS
{
    public interface ICPU
    {
        float[,] AttackPercent { get; }
        float[,] AttackSuccessPercent { get; }
    }
    
    public class CPUEasy : ICPU
    {
        public float[,] AttackPercent => new float[3, 3]
        {
            { 4, 5, 1},
            { 4, 6, 0},
            { 8, 2, 0},
        };
        
        public float[,] AttackSuccessPercent => new float[3, 2]
        {
            {7, 3},
            {6, 4},
            {0, 10}
        };
    }
    
    public class CPUNormal : ICPU
    {
        public float[,] AttackPercent => new float[3, 3]
        {
            { 3, 4, 3},
            { 2, 7, 1},
            { 6, 3, 1},
        };
        
        public float[,] AttackSuccessPercent => new float[3, 2]
        {
            {8, 2},
            {7, 3},
            {1, 9}
        };
    }
    
    public class CPUHard : ICPU
    {
        public float[,] AttackPercent => new float[3, 3]
        {
            { 2, 4, 4},
            { 3, 5, 2},
            { 5, 4, 1},
        };
        
        public float[,] AttackSuccessPercent => new float[3, 2]
        {
            {9, 1},
            {8, 2},
            {3, 7}
        };
    }
}