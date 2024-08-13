using System;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class PowerUpTrigger : MonoBehaviour
    {
        [SerializeField] private PlayerMovment player;
        public async void OnTriggerEnter(Collider other)
        {
            IPowerUp powerUp = other.GetComponent<IPowerUp>();
            if (powerUp != null)
            {
                await powerUp.ApplyPowerUp(player);
            }
        }
    }   
}