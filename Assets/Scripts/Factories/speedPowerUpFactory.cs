using UnityEngine;

namespace DefaultNamespace
{
    public class speedPowerUpFactory : IFactory
    {
        private GameObject _speedPowerUpPrefab;

        public speedPowerUpFactory(GameObject speedPowerUpPrefab)
        {
            _speedPowerUpPrefab = speedPowerUpPrefab;
        }
        
        public void Create(Vector3 spawnPosition)
        {
            GameObject.Instantiate(_speedPowerUpPrefab, spawnPosition, Quaternion.Euler(0,0,0));
        }
    }
}
