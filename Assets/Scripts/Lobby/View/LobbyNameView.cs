using TMPro;
using UnityEngine;

namespace TapTest
{
    public class LobbyNameView : MonoBehaviour
    {
        [field: SerializeField]
        public  TMP_InputField PlayerName { get; private set; }
    }
}