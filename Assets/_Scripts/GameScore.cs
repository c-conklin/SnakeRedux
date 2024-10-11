using System;
using UnityEngine;

namespace _Scripts
{
    [CreateAssetMenu(fileName = "GameScore", menuName = "Game/Score", order = 0)]
    public class GameScore : ScriptableObject
    {
        private int score;
        
        public int Score => score;

        private void OnEnable()
        {
            FoodSpawner.OnFoodEaten += AddScore;
        }
        
        private void OnDisable()
        {
            FoodSpawner.OnFoodEaten -= AddScore;
        }
        
        public void AddScore()
        {
            score++;
        }
        
        public void ResetScore()
        {
            score = 0;
        }
        
    }
}
