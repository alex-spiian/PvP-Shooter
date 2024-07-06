using UnityEngine;

namespace DefaultNamespace
{
    public class InputHandler
    {
        public Vector3 GetMovementInput()
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            return new Vector3(horizontal, 0, vertical).normalized;
        }


        public Vector3 GetYMouseRotation()
        {
            var yRotation = Input.GetAxisRaw("Mouse X");
            return new Vector3(0, yRotation, 0);
        }
        
        public Vector3 GetXMouseRotation()
        {
            var xRotation = Input.GetAxisRaw("Mouse Y");
            return new Vector3(xRotation, 0, 0);
        }
    }
}