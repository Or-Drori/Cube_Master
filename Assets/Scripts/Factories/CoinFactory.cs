using UnityEngine;

namespace DefaultNamespace
{
    public class CoinFactory : IFactory
    {
        private Coin _coinPrefab;

        public CoinFactory(Coin coinPrefab)
        {
            _coinPrefab = coinPrefab;
        }
        
        public void Create(Vector3 spawnPosition)
        {
            var coin = Object.Instantiate(_coinPrefab, spawnPosition, Quaternion.Euler(0,0,0));
            coin.OnCollected += ScoreManager.AddScore;
        }
    }
}