using System;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public class PowerUpTrigger : MonoBehaviour
    {
        [SerializeField] private PlayerMovment player;
        public void OnTriggerEnter(Collider other)
        {
            IPowerUp powerUp = other.GetComponent<IPowerUp>();
            powerUp?.ApplyPowerUp(player);
        }
    }   
}