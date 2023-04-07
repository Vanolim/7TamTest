using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class GamePhotonService : MonoBehaviourPunCallbacks,
        IOnEventCallback
    {
        [SerializeField]
        private Character _prefab;

        private CoinWallet _coinWallet;

        private const byte CharacterSpawnEventCode = 1;
        private const byte CharacterIsDie = 2;

        [Inject]
        private void Construct(CoinWallet coinWallet)
        {
            _coinWallet = coinWallet;
        }

        public void RegisterCharacter(Character character)
        {
            PhotonView photonView = character.PhotonView;
            if (PhotonNetwork.AllocateViewID(photonView))
            {
                object[] data = new object[]
                {
                    character.transform.position, character.transform.rotation, photonView.ViewID
                };

                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.AddToRoomCache
                };

                SendOptions sendOptions = new SendOptions()
                {
                    Reliability = true
                };

                PhotonNetwork.RaiseEvent(CharacterSpawnEventCode, data, raiseEventOptions, sendOptions);
            }
            else
            {
                Debug.LogError("Failed allocate");
            }
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code == CharacterSpawnEventCode)
            {
                object[] data = (object[])photonEvent.CustomData;

                Character character = Instantiate(_prefab, (Vector3)data[0], (Quaternion)data[1])
                    .GetComponent<Character>();
                character.PhotonView.ViewID = (int)data[2];
            }
        }

        public void SendMessageCharacterIsDie()
        {
            object[] content = { PhotonNetwork.NickName, _coinWallet.Value };
            RaiseEventOptions raiseEventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.MasterClient }; 
            PhotonNetwork.RaiseEvent(CharacterIsDie, content, raiseEventOptions, SendOptions.SendReliable);
        }
    }
}