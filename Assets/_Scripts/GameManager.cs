using _Scripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameScore gameScore;
    public PlayerMovement playerMovement;
    public GameStats gameStats;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
        UpdateStats();
        
    }
    
    public void ResetGame()
    {
        gameScore.ResetScore();
        playerMovement.ResetPlayerPosition();
        UpdateStats();
    }
    
    public void AddScore()
    {
        gameScore.AddScore();
        UpdateStats();
    }
    
    public void UpdateStats()
    {
        gameStats.UpdateStats();
    }
    
    
}
