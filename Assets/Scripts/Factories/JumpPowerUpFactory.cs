using UnityEngine;

namespace DefaultNamespace
{
    public class JumpPowerUpFactory : IFactory
    {
        private GameObject _jumpPowerUpPrefab;

        public JumpPowerUpFactory(GameObject jumpPowerUpPrefab)
        {
            _jumpPowerUpPrefab = jumpPowerUpPrefab;
        }
        
        public void Create(Vector3 spawnPosition)
        {
            GameObject.Instantiate(_jumpPowerUpPrefab, spawnPosition, Quaternion.Euler(0,0,0));
        }
    }
}
