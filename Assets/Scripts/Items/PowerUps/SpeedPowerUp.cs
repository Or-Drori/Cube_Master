using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class SpeedPowerUp : MonoBehaviour , IPowerUp
    {
        public async UniTask ApplyPowerUp(PlayerMovment player)
        {
            await TimedPowerUp(3, player);
        }
        
        private async UniTask TimedPowerUp(float time, PlayerMovment player)
        {
            SpeedUp(player);
            UnityUtils.DisableMeshRenderersAndColliders(gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(time));
            SpeedDown(player);
            Destroy(gameObject);
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