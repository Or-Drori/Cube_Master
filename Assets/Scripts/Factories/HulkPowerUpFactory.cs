using UnityEngine;

namespace DefaultNamespace
{
    public class HulkPowerUpFactory : IFactory
    {
        private GameObject _hulkPowerUpPrefab;

        public HulkPowerUpFactory(GameObject hulkPowerUpPrefab)
        {
            _hulkPowerUpPrefab = hulkPowerUpPrefab;
        }
        
        public void Create(Vector3 spawnPosition)
        {
            GameObject.Instantiate(_hulkPowerUpPrefab, spawnPosition, Quaternion.Euler(0,0,0));
        }
    }
}
