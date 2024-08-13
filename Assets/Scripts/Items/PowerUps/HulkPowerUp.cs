using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class HulkPowerUp : MonoBehaviour , IPowerUp
    {
        public async UniTask ApplyPowerUp(PlayerMovment player)
        {
            await TimedPowerUp(3, player);
        }
        
        private async UniTask TimedPowerUp(float time, PlayerMovment player)
        {
            ScaleUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(time));
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