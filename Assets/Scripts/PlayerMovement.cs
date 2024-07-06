using Mirror.Experimental;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(NetworkRigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5;
        
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 velocity)
        {
            if (velocity != Vector3.zero)
            {
                velocity *= _speed;
                _rigidbody.MovePosition(_rigidbody.position + velocity * Time.deltaTime);
            }
        }
    }
}