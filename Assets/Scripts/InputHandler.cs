using UnityEngine;

namespace DefaultNamespace
{
    public class InputHandler
    {
        public Vector3 GetMovementInput(Transform transform)
        {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");
            return (transform.right * horizontal) + (transform.forward * vertical).normalized;
        }


        public Vector3 GetYMouseRotation()
        {
            var yRotation = Input.GetAxisRaw("Mouse X");
            return new Vector3(0, yRotation, 0);
        }
    }
}