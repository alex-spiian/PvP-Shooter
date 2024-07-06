using Mirror;
using UnityEngine;

namespace DefaultNamespace
{
    public class Projectile : NetworkBehaviour
    {
        [SerializeField]
        private float _destroyAfter = 2;
        
        [SerializeField]
        private Rigidbody _rigidBody;
        
        [SerializeField]
        private float _force = 5;

        public override void OnStartServer()
        {
            Invoke(nameof(DestroySelf), _destroyAfter);
        }

        private void Start()
        {
            _rigidBody.AddForce(transform.forward * _force);
        }

        [Server]
        private void DestroySelf()
        {
            NetworkServer.Destroy(gameObject);
        }
        
        [ServerCallback]
        private void OnTriggerEnter(Collider co) => DestroySelf();
    }
}