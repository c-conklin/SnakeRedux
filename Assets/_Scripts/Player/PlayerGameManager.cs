using UnityEngine;

namespace _Scripts.Player
{
    public class PlayerGameManager : MonoBehaviour
    {
        public PlayerDataSO playerDataAsset;
        [HideInInspector] public PlayerDataSO runtimePlayerData;

        void Awake()
        {
            runtimePlayerData = Instantiate(playerDataAsset);
        }
    }
}
