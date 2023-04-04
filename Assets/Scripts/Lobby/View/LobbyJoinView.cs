using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class LobbyJoinView : MonoBehaviour
    {
        [SerializeField]
        private  TMP_InputField _roomName;

        [SerializeField]
        private Button _joinRoom;
        
        public event Action<string> OnJoin;

        private void TryCreateEvent()
        {
            if (_roomName.text == "")
            {
                Debug.Log("Error");
                return;
            }
            
            OnJoin?.Invoke(_roomName.text);
        }

        private void OnEnable()
        {
            _joinRoom.onClick.AddListener(TryCreateEvent);
        }

        private void OnDisable()
        {
            _joinRoom.onClick.RemoveListener(TryCreateEvent);
        }
    }
}