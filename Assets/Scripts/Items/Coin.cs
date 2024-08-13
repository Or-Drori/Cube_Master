using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        
        public event Action OnCollected;
        
        public void OnTriggerEnter(Collider _collider)
        {
            if (_collider.gameObject.CompareTag("Player"))
            {
                OnCollected?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}