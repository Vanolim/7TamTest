using UnityEngine;

namespace TapTest
{
    [CreateAssetMenu(menuName = "Game/GameSetting")]
    public class GameSetting : ScriptableObject
    {
        [field: SerializeField] 
        public int CountCoins { get; private set; }
        
        [field: SerializeField] 
        public int MinCountActivateGame { get; private set; }
        
        [field: SerializeField] 
        public float WaitBootstrapperScene { get; private set; }
        
        
        [field: SerializeField] 
        public float WaitFinishedLoadLobby { get; private set; }
    }
}