using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable_Objects/Movement/Settings")]
public class MoveSettings : ScriptableObject
{
    [Header("X / Z")]
    [SerializeField] private float _walkSpeed = 5.0f;
    public float walkSpeed { get { return _walkSpeed; } private set { _walkSpeed = value; } }

    [SerializeField] private float _runSpeed = 8.0f;
    public float runSpeed { get { return _runSpeed; } private set { _runSpeed = value; } }

    [SerializeField, Range(1, 10)] private float _acceleration = 2.5f;
    public float acceleration { get { return _acceleration; } private set { _acceleration = value; } }

    [Header("Y")]
    [SerializeField] private float _jumpForce = 13.0f;
    public float jumpForce { get { return _jumpForce; } private set { _jumpForce = value; } }

    [SerializeField] private float _antiBump = 4.5f;
    public float antiBump { get { return _antiBump; } private set { _antiBump = value; } }

    [SerializeField] private float _gravity = 30.0f;
    public float gravity { get { return _gravity; } private set { _gravity = value; } }
}
