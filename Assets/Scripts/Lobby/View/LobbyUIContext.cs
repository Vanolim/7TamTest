using UnityEngine;

namespace TapTest
{
    public class LobbyUIContext : MonoBehaviour
    {
        [field: SerializeField]
        public LobbyNameView LobbyNameView { get; private set; }
        
        [field: SerializeField]
        public LobbyJoinView LobbyJoinView { get; private set; }
        
        [field: SerializeField]
        public LobbyCreatorView LobbyCreatorView { get; private set; }
    }
}