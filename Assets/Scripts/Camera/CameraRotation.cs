using UnityEngine;

namespace DefaultNamespace
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] float rotationSpeed = 5.0f;
        [SerializeField] Vector3 offset  = new (0, 1.5f, -6);
        

        void LateUpdate()
        {
            RotateCamera();
        }
        
        private void RotateCamera()
        {
            transform.position = player.position + offset;
            float horizontalInput = Input.GetAxis("Mouse X");
            transform.RotateAround(player.position, Vector3.up, horizontalInput * rotationSpeed);
            offset = transform.position - player.position;
        }
    }
}