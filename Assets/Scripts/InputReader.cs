using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = System.Numerics.Vector3;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "InputReader")]
    public class InputReader : ScriptableObject , InputMap.IPlayerActions
    {
        private InputMap _inputMap;
        public void OnEnable()
        {
            if (_inputMap == null)
            {
                _inputMap = new InputMap();
                _inputMap.Player.SetCallbacks(this);
            }
            EnablePlayer();
        }

        private void EnablePlayer()
        {
            _inputMap.Player.Enable();
        }
        private void DisablePlayer()
        {
            _inputMap.Player.Disable();
        }
        
        public event Action<Vector2> moveEvent;
        public event Action jumpEvent;
        
        public void OnMove(InputAction.CallbackContext context)
        {
             moveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            jumpEvent?.Invoke();
        }
    }
}