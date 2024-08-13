using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GenralFactory : MonoBehaviour
    {
        [SerializeField] private Coin coinPrefab;
        [SerializeField] private GameObject speedPowerUpPrefab;
        [SerializeField] private GameObject hulkPowerUpPrefab;
        [SerializeField] private GameObject jumpPowerUpPrefab;
        private Dictionary<SpawnableType, IFactory> factories;
        
        private void Awake()
        {
            factories = new Dictionary<SpawnableType, IFactory>
            {
                { SpawnableType.Coin, new CoinFactory(coinPrefab)},
                { SpawnableType.speedPowerUp, new speedPowerUpFactory(speedPowerUpPrefab)},
                { SpawnableType.jumpPowerUp, new speedPowerUpFactory(jumpPowerUpPrefab)},
                { SpawnableType.hulkPowerUp, new speedPowerUpFactory(hulkPowerUpPrefab)}
            };
           
        }
        
        public void CreateByType(SpawnableType spawnableType, Vector3 spawnPosition)
        {
            factories[spawnableType].Create(spawnPosition);
        }
        
    }

    public enum SpawnableType
    {
        Coin,
        speedPowerUp,
        hulkPowerUp,
        jumpPowerUp
    }
}