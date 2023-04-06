using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class CharacterHealthView : MonoBehaviour
    {
        [SerializeField]
        private PhotonView _photonView;
        
        [SerializeField]
        private Transform _pivot;
        
        [SerializeField]
        private Image _image;
        
        private void LateUpdate()
        {
            UpdateHealthViewTransform();
            
            _photonView.RPC("UpdateHealthBatTransform", RpcTarget.Others, 
                transform.position);
        }

        private void UpdateHealthViewTransform()
        {
            transform.position = _pivot.position;
            transform.rotation = Quaternion.identity;
        }

        [PunRPC]
        private void UpdateHealthBatTransform(Vector3 position)
        {
            transform.position = position;
            transform.rotation = Quaternion.identity;
        }

        public void UpdateHealthBar(float maxHealth, float currentHealth)
        {
            _image.fillAmount = currentHealth / maxHealth;
        }
    }
}