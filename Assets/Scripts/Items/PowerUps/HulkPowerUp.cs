using System.Collections;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class HulkPowerUp : MonoBehaviour , IPowerUp
    {
        public void ApplyPowerUp(PlayerMovment player)
        {
            StartCoroutine(TimedPowerUp(3, player));
        }
        
        IEnumerator TimedPowerUp(float time, PlayerMovment player)
        {
            ScaleUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            yield return new WaitForSeconds(time);
            ScaleDown(player);
            Destroy(gameObject);
        }
        private void ScaleUp(PlayerMovment player)
        {
            player.transform.localScale *= 2;
        }
        private void ScaleDown(PlayerMovment player)
        {
            player.transform.localScale /= 2;
        }
    }
}