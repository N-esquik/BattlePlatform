using System;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimation))]
[RequireComponent(typeof(Rotation))]
[RequireComponent (typeof(EnemyPatrol))]

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private float _aggerssionRange = 5f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _distanceStop = 1f;
    [SerializeField] private LayerMask _playerMask;

    private Transform _player;
    private EnemyPatrol _enemyPatrol;
    private Rotation _rotation;
    private EnemyAnimation _enemyAnimation;

    private int _rotationLeft = 180;
    private int _rotationRight = 0;
    private float _speedAnimation = 1;
    private bool _isMoving = true;

    public event Action StartMoved;

    private void Awake()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
        _rotation = GetComponent<Rotation>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
    }

    private void Update()
    {
        if (_player == null)
        {
            TryFindPlayer();
        }
        else
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);
            
            if (distanceToPlayer <= _distanceStop)
            {
                _isMoving = false;
                _enemyAnimation.Move(0);
            }
            else
            {
                _isMoving = true;
            }

            if (_isMoving == true)
            {
                ChasePlayer();
            }
        }
    }

    private void TryFindPlayer()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _aggerssionRange, _playerMask);

        if (hitColliders.Length > 0)
        {
            _player = hitColliders[0].transform;
            StartMoved?.Invoke();
        }
    }

    private void ChasePlayer()
    {
        if (_player != null)
        {
            Vector3 direction = _player.position - transform.position;
            _enemyAnimation.Move(_speedAnimation);
            _rotation.Rotate(direction.x, _rotationLeft, _rotationRight);

            transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, _player.position) > _aggerssionRange)
            {
                _player = null;
                StartMoved?.Invoke();
            }
        }
    }
}
