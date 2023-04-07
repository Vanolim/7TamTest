using TMPro;
using UnityEngine;

namespace TapTest
{
    public class EntryTemplate : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _name;
        
        [SerializeField]
        private TMP_Text _score;
        
        [SerializeField]
        private TMP_Text _pos;

        public void SetParametrs(string name, string score, string pos)
        {
            _pos.text = pos;
            _name.text = name;
            _score.text = score;
        }
    }
}