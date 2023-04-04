using TMPro;
using UnityEngine;

namespace TapTest
{
    public class LogView : MonoBehaviour
    {
        [SerializeField]
        private Color _errorColor;

        [SerializeField]
        private Color _successColor;
        
        [SerializeField]
        private TMP_Text _text;

        private void SetColorNewMessage(LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    _text.color = _errorColor;
                    break;
                case LogType.Success:
                    _text.color = _successColor;
                    break;
                
                default:
                    _text.color = Color.white;
                    break;
            }
        }

        public void PrintLog(string message, LogType logType)
        {
            SetColorNewMessage(logType);
            _text.text += "\n";
            _text.text += message;
        }
    }
}