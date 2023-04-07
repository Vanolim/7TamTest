using TMPro;
using UnityEngine;

namespace TapTest
{
    public class EntryTemplate : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _playerName;
        
        [SerializeField]
        private TMP_Text _countCoins;
        
        [SerializeField]
        private TMP_Text _pos;

        public void SetParameters(string playerName, string score, string position)
        {
            _pos.text = position;
            _countCoins.text = score;

            if(playerName != "")
                _playerName.text = playerName;
        }
    }
}