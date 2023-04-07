using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class FinishGameView : MonoBehaviour,
        IInitializable,
        IActivable
    {
        [SerializeField]
        private PhotonView _photonView;
        
        [SerializeField]
        private EntryTemplate _entryTemplate;

        [SerializeField]
        private Transform _entryContainer;

        [SerializeField]
        private float _templateHeight;

        [SerializeField]
        private Button _leave;

        public event Action OnLeaved;

        private void LeavedEvent() => OnLeaved?.Invoke();

        public void FormHighscores(CharacterData[] characterDatas)
        {
            for (int i = 0; i < characterDatas.Length; i++)
            {
                EntryTemplate entry = Instantiate(_entryTemplate, _entryContainer)
                    .GetComponent<EntryTemplate>();

                CharacterData characterData = characterDatas[i];
                entry.SetParametrs(characterData.Name, characterData.CountCoins.ToString(), i.ToString());
                
                RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0, _templateHeight * i);
            }
        }
        public void Activate() => _photonView.RPC("RPC_Activate", RpcTarget.AllBuffered);

        public void Deactivate() => _photonView.RPC("RPC_Deactivate", RpcTarget.AllBuffered);

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);
        

        public void Initialize() => _leave.onClick.AddListener(LeavedEvent);
        private void OnDestroy() => _leave.onClick.RemoveListener(LeavedEvent);
    }
}