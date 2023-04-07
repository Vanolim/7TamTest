using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class FinishedViewSpawner
    {
        public FinishGameView Spawn() =>
            PhotonNetwork.Instantiate("FinishGameView", Vector3.zero, Quaternion.identity)
                .GetComponent<FinishGameView>();
    }
}