using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private float _friction = .1f;
    [SerializeField]
    private InputActionReference _steering;
    [SerializeField]
    private float _steeringSpeed = 00f;
    [SerializeField]
    private float _speed = 5f;
    private CharacterController _control;
    private Quaternion _direction;
    private Vector3 _velocity;
    void Start()
    {
        _steering.action.Enable();
        _direction = gameObject.transform.rotation;
        _control = this.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _direction = gameObject.transform.rotation;
        Debug.Log(_steering.action.ReadValue<Vector2>().x);
        if(_steering.action.ReadValue<Vector2>().x != 0)
        {
            _direction *= Quaternion.Euler(0, _steering.action.ReadValue<Vector2>().x * Time.deltaTime, 0);
            gameObject.transform.rotation *= _direction;
        }
        if(_control != null)
        {
            _control.Move(_velocity * Time.deltaTime);
        }
        _velocity -= _velocity * _friction;
    }
}
