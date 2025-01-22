using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(Rotation))]

public class EmenyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    private Vector3 _currentWaypoint;
    private Rotation _rotation;
    private EnemyAnimation _enemyAnimation;

    private int _rotationLeft = 180;
    private int _rotationRight = 0;
    private float _speedAnimation = 1;
    private float _distanceToTarget = 0.1f;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _rotation = GetComponent<Rotation>();
        _currentWaypoint = _pointA.position;
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector3 direction = _currentWaypoint - transform.position;
        _enemyAnimation.Move(_speedAnimation);
        _rotation.Rotate(direction.x,_rotationLeft, _rotationRight);

        transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint, _speed * Time.deltaTime);

        if (IsTargetReached())
        {
            if (_currentWaypoint == _pointA.position)
            {
                _currentWaypoint = _pointB.position;
            }
            else 
            {
                _currentWaypoint = _pointA.position;
            }
        }
    }

    private bool IsTargetReached()
    {
        return transform.position.IsEnoughClose(_currentWaypoint, _distanceToTarget);
    }
}
