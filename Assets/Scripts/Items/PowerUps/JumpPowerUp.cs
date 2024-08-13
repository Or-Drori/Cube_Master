using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class JumpPowerUp : MonoBehaviour , IPowerUp
    {
        public void ApplyPowerUp(PlayerMovment player)
        {
            StartCoroutine(TimedPowerUp(3, player));
        }
        
        private IEnumerator TimedPowerUp(float time, PlayerMovment player)
        {
            JumpUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            yield return new WaitForSeconds(time);
            JumpDown(player);
        }
        private void JumpUp(PlayerMovment player)
        {
            player.JumpForce *= 2;
        }
        private void JumpDown(PlayerMovment player)
        {
            player.JumpForce /= 2;
        }
    }
}