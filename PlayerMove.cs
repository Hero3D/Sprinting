using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private MoveSettings _settings = null;

    private bool _grounded;

    private float _speed;
    private float _changeSpeed;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        DefaultMovement();
        CheckGrounded();
        CheckSpeed();
    }

    private void CheckGrounded()
    {
        if (_grounded != _controller.isGrounded)
        {
            EventsLib.GroundedChanged.CallEvent(new EventArgsLib.GroundedChangedEventArgs(_controller.isGrounded));
            _grounded = _controller.isGrounded;
        }
    }

    private void CheckSpeed()
    {
         if (_changeSpeed != TrueSpeed())
        {
            EventsLib.SpeedChanged.CallEvent(new EventArgsLib.SpeedChangedEventArgs(TrueSpeed()));
            _changeSpeed = TrueSpeed();
        }
    }

    private float TrueSpeed()
    {
        return new Vector3(_controller.velocity.x, 0, _controller.velocity.z).magnitude;
    }

    private void FixedUpdate()
    {
        _controller.Move(_moveDirection * Time.deltaTime);
    }

    private bool Sprinting()
    {
        if (!Input.GetKey(KeyCode.LeftShift)) return false;
        if (!_controller.isGrounded) return false;
     // if (PlayerInput.y <= 0) return false;
        return true;
    }

    private float DesiredSpeed()
    {
    //  if (Crouching()) return _settings.crouchSpeed;
        return Sprinting() ? _settings.runSpeed : _settings.walkSpeed;
    }

    private void SetSpeed()
    {
        _speed = Mathf.Lerp(_speed, DesiredSpeed(), _settings.acceleration * Time.deltaTime);
    }

    private void DefaultMovement()
    {
        if (_controller.isGrounded)
        {
            SetSpeed();

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            _moveDirection.x = input.x * _speed;
            _moveDirection.z = input.y * _speed;
            _moveDirection.y = -_settings.antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            _moveDirection.y -= _settings.gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        _moveDirection.y += _settings.jumpForce;
    }
}

