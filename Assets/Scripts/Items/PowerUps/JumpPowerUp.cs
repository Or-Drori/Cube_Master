using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class JumpPowerUp : MonoBehaviour , IPowerUp
    {
        public async UniTask ApplyPowerUp(PlayerMovment player)
        {
            await TimedPowerUp(3, player);
        }
        
        private async UniTask TimedPowerUp(float time, PlayerMovment player)
        {
            JumpUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(time));
            JumpDown(player);
            Destroy(gameObject);
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