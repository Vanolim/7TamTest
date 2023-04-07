using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class FinishedViewSpawner
    {
        public HigscoresView Spawn() =>
            PhotonNetwork.Instantiate("FinishGameView", Vector3.zero, Quaternion.identity)
                .GetComponent<HigscoresView>();
    }
}