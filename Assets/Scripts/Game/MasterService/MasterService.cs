using ExitGames.Client.Photon;
using Photon.Realtime;
using UnityEngine;

namespace TapTest
{
    public class MasterService : IOnEventCallback
    {
        public void OnEvent(EventData photonEvent)
        {
            byte eventCode = photonEvent.Code;

            if (eventCode == 2)
            {
                object[] data = (object[])photonEvent.CustomData;

                string name = (string)data[0];
                int coin = (int)data[1];
                
                Debug.Log(name + " " + coin);
            }
        }
    }
}