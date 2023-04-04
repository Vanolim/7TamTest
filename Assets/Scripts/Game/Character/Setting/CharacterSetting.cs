using UnityEngine;

namespace TapTest
{
    [CreateAssetMenu(menuName = "Game/CharacterSetting")]
    public class CharacterSetting : ScriptableObject
    {
        [field: SerializeField]
        public float GunReloadTime { get; private set; }
    }
}