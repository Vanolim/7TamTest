using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class LobbyCreatorView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _roomName;

        [SerializeField]
        private Button _createRoom;
        
        public event Action<string> OnCreate;

        private void TryCreateEvent()
        {
            if (_roomName.text == "")
            {
                return;
            }
            
            OnCreate?.Invoke(_roomName.text);
        }

        private void OnEnable()
        {
            _createRoom.onClick.AddListener(TryCreateEvent);
        }

        private void OnDisable()
        {
            _createRoom.onClick.RemoveListener(TryCreateEvent);
        }
    }
}