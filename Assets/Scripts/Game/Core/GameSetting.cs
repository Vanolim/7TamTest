using UnityEngine;

namespace TapTest
{
    [CreateAssetMenu(menuName = "Game/GameSetting")]
    public class GameSetting : ScriptableObject
    {
        [field: SerializeField] 
        public int CountCoins { get; private set; }
    }
}