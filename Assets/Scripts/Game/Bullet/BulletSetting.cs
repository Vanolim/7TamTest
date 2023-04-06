using UnityEngine;

namespace TapTest
{
    [CreateAssetMenu(menuName = "Game/BulletSetting")]
    public class BulletSetting : ScriptableObject
    {
        [field: SerializeField] 
        public float Damage { get; private set; }
        
        [field: SerializeField] 
        public float SpeedMovement { get; private set; }
    }
}