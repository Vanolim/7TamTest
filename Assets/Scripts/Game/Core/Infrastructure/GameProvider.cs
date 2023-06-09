using UnityEngine;

namespace TapTest
{
    public class GameProvider : MonoBehaviour
    {
        [field: SerializeField]
        public CharacterSetting CharacterSetting { get; private set; }

        [field: SerializeField]
        public Character Character { get; private set; }
        
        [field: SerializeField]
        public InputPanel InputPanel { get; private set; }
        
        [field: SerializeField]
        public TickableService TickableService { get; private set; }
        
        [field: SerializeField]
        public GamePhotonService GamePhotonService { get; private set; }

        [field: SerializeField]
        public Bullet Bullet { get; private set; }
        
        [field: SerializeField]
        public BulletSetting BulletSetting { get; private set; }
        
        [field: SerializeField]
        public GameBoard GameBoard { get; private set; }
        
        [field: SerializeField]
        public HigscoresView HigscoresView { get; private set; }
    }
}