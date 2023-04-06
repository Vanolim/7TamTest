using System;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace TapTest
{
    public class GamePhotonService : MonoBehaviourPunCallbacks,
        IOnEventCallback
    {
        [SerializeField]
        private Character _prefab;
        
        [SerializeField]
        private Bullet _bullet;
        
        private const byte CharacterSpawnEventCode = 1;
        private const byte BulletSpawnEventCode = 2;

        private int start = 100;

        public event Action OnLeaveRoom;
        
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            OnLeaveRoom?.Invoke();
        }

        public override void OnPlayerEnteredRoom(Player player)
        {
            
        }
        
        public override void OnPlayerLeftRoom(Player player)
        {
            
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
        
        public void RegisterBullet(Bullet bullet)
        {
            PhotonView photonView = bullet.PhotonView;
            if (PhotonNetwork.AllocateViewID(photonView))
            {
                object[] data = new object[]
                {
                    bullet.transform.position, bullet.transform.rotation, photonView.ViewID
                };

                RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others,
                    CachingOption = EventCaching.DoNotCache
                };

                SendOptions sendOptions = new SendOptions()
                {
                    Reliability = true
                };

                PhotonNetwork.RaiseEvent(BulletSpawnEventCode, data, raiseEventOptions, sendOptions);
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
            else if (photonEvent.Code == BulletSpawnEventCode)
            {
                object[] data = (object[])photonEvent.CustomData;

                Bullet bullet = Instantiate(_bullet, (Vector3)data[0], (Quaternion)data[1]);
                bullet.PhotonView.ViewID = (int)data[2];
            }
        }
    }
}