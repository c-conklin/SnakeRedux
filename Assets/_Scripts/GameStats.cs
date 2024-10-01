using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    [SerializeField] private GameObject player;
    TextMeshProUGUI _textMesh;
    
    private StringBuilder stringBuilder = new StringBuilder();

    // Start is called before the first frame update
    void Start()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        stringBuilder.AppendLine($"Player Position: {player.transform.position}");
        stringBuilder.AppendLine($"Time Fixed Delta Time: {Time.fixedDeltaTime}");
        stringBuilder.AppendLine($"Time Delta Time: {Time.deltaTime}");
        stringBuilder.AppendLine($"Time Scale: {Time.timeScale}");
        stringBuilder.AppendLine($"Time Time: {Time.time}");
    } 
}
