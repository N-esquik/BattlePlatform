using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent (typeof(Rotation))]

public class EmenyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private Transform _currentWaypoint;
    private Rotation _rotation;
    private EnemyAnimation _enemyAnimation;

    private int _rotationLeft = 180;
    private int _rotationRight = 0;
    private bool _isRight;
    private float _speedAnimation = 1;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _rotation = GetComponent<Rotation>();
        _currentWaypoint = _pointA;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector2 direction = _currentWaypoint.position - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speed * Time.deltaTime);

        _rotation.Rotate(direction.x, _rotationLeft, _rotationRight);

        _enemyAnimation.Move(_speedAnimation);

        if(Vector2.Distance(transform.position, _currentWaypoint.position) < 0.1f)
        {
            if (_isRight)
            {
                _currentWaypoint = _pointB;
                _isRight = false;
            }
            else
            {
                _currentWaypoint = _pointA;
                _isRight = true;
            }
        }
    }
}
