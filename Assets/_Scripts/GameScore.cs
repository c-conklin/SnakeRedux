using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "GameScore", menuName = "Game/Score", order = 0)]
    public class GameScore : ScriptableObject
    {
        public int score;
        
        public void AddScore(int amount)
        {
            score += amount;
        }
        
        public void ResetScore()
        {
            score = 0;
        }
        
    }
}
