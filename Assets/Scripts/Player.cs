using DefaultNamespace;
using Mirror;
using UnityEngine;
using Input = UnityEngine.Input;

public class Player : NetworkBehaviour
{
    [SerializeField]
    private TextMesh  _healthBar;

    [SerializeField]
    private GameObject _projectilePrefab;
    
    [SerializeField]
    private Transform _muzzle;
    
    [SerializeField]
    private Camera _playerCamera;
    
    [SerializeField]
    private Transform _weapon;

    [SerializeField]
    private int _speed = 5;

    [SyncVar]
    [SerializeField]
    private int _health = 20;

    private InputHandler _inputHandler;

    private void Start()
    {
        if (isLocalPlayer)
        {
            _inputHandler = new InputHandler();
            _playerCamera.enabled = true;
        }
        else
        {
            _playerCamera.enabled = false;
        }
    }

    private void Update()
    {
        _healthBar.text = new string('-', _health);
        
        if (!Application.isFocused) return;
        if (isLocalPlayer)
        {
            var velocity = _inputHandler.GetMovementInput();
            var rotation = _inputHandler.GetYMouseRotation();
            var cameraRotation = _inputHandler.GetXMouseRotation();
            _weapon.Rotate(cameraRotation);

            _playerCamera.transform.Rotate(-cameraRotation);
            transform.Translate(velocity * Time.deltaTime * _speed);
            transform.Rotate(rotation);
            
            if (Input.GetMouseButtonDown(0))
            {
                CmdFire();
            }
        }
    }

    [Command]
    private void CmdFire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _muzzle.position, _muzzle.rotation);
        NetworkServer.Spawn(projectile);
    }
    
    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            if (!isLocalPlayer)
            {
                return;
            }
            Debug.Log("i got damage");
            --_health;
            if (_health == 0)
                NetworkServer.Destroy(gameObject);
        }
    }
    
}