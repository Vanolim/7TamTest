using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class HigscoresView : MonoBehaviour,
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

        public void Test(string name, string dataCoins, int i) => 
            _photonView.RPC("RPC_AddTemplate", RpcTarget.AllBuffered, name, dataCoins, i);

        public void Activate() => _photonView.RPC("RPC_Activate", RpcTarget.AllBuffered);

        public void Deactivate() => _photonView.RPC("RPC_Deactivate", RpcTarget.AllBuffered);

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);

        [PunRPC]
        private void RPC_AddTemplate(string name, string dataCoins, int pos)
        {
            EntryTemplate entry = Instantiate(_entryTemplate, _entryContainer)
                .GetComponent<EntryTemplate>();
            
            entry.SetParameters(name, dataCoins, (pos + 1).ToString());
                
            RectTransform entryRectTransform = entry.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -_templateHeight * pos);
        }
    }
}