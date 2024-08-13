using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DefaultNamespace.PowerUps
{
    public interface IPowerUp
    {
        public UniTask ApplyPowerUp(PlayerMovment player);
    }
}