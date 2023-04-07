using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class FinishGameView : MonoBehaviour,
        IActivable
    {
        [field:SerializeField]
        public PhotonView PhotonView;
        
        [SerializeField]
        private EntryTemplate _entryTemplate;

        [SerializeField]
        private Transform _entryContainer;

        [SerializeField]
        private float _templateHeight;

        public void Test(string name, string dataCoins, int i)
        {
            PhotonView.RPC("RPC_Init", RpcTarget.AllBuffered, name, dataCoins, i);
        }

        public void Activate()
        {
            PhotonView.RPC("RPC_Activate", RpcTarget.AllBuffered);
        }

        public void Deactivate() => PhotonView.RPC("RPC_Deactivate", RpcTarget.AllBuffered);

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);

        [PunRPC]
        private void RPC_Init(string name, string dataCoins, int i)
        {
            EntryTemplate entry = Instantiate(_entryTemplate, _entryContainer)
                .GetComponent<EntryTemplate>();
            
            entry.SetParametrs(name, dataCoins, i.ToString());
                
            RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -_templateHeight * i);
        }
    }
}