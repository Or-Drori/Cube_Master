using System.Collections;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class SpeedPowerUp : MonoBehaviour , IPowerUp
    {
        public void ApplyPowerUp(PlayerMovment player)
        {
            StartCoroutine(TimedPowerUp(3, player));
        }
        
        IEnumerator TimedPowerUp(float time, PlayerMovment player)
        {
            SpeedUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            yield return new WaitForSeconds(time);
            SpeedDown(player);
        }
        private void SpeedUp(PlayerMovment player)
        {
            player.Speed *= 2;
        }
        private void SpeedDown(PlayerMovment player)
        {
            player.Speed /= 2;
        }

    }
}