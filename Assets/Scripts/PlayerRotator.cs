using Mirror.Experimental;
using UnityEngine;

namespace DefaultNamespace
{
    
    [RequireComponent(typeof(NetworkRigidbody))]
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed;
        
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Rotate(Vector3 rotation)
        {
            rotation *= _rotationSpeed;
            _rigidbody.MoveRotation(_rigidbody.rotation * Quaternion.Euler(rotation));
        }
    }
}