using Photon.Pun;

namespace TapTest
{
    public interface IDoingDamage
    {
        public void Destroy();
        public void TakeDamageEvent(PhotonView target);
    }
}