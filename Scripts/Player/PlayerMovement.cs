using UnityEngine;

[RequireComponent(typeof(Rotation))]
[RequireComponent (typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Rotation _rotation;

    private int _rotationLeft = 180;
    private int _rotationRight = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rotation = GetComponent<Rotation>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis(Horizontal);

        _rigidbody.velocity = new Vector2(moveInput * _speed, _rigidbody.velocity.y);

        Rotate();
    }

    private void Rotate()
    {
        _rotation.Rotate(Input.GetAxis(Horizontal),_rotationLeft,_rotationRight);
    }
}
