using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _cooldown = 2f;

    private InitAnimation _animation;
    private AnimationAttackEvents _events;
    private Enemy _enemy;

    private float _nextFireTime;
    private bool _isAttackFireball = true;

    public event Action FireballShooting;

    private void Awake()
    {
        _animation = GetComponent<InitAnimation>();
        _events = GetComponent<AnimationAttackEvents>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        ShootFireball();
    }

    private void OnEnable()
    {
        _events.ResetPlayerAttacked += ResetAttack;
    }

    private void OnDisable()
    {
        _events.ResetPlayerAttacked -= ResetAttack;
    }

    private void ShootFireball()
    {
        if (_nextFireTime > 0)
        {
            _nextFireTime -= Time.deltaTime;
        }

        if (InputService.SetKeyCode(InputService.KeySpace) && _nextFireTime <= 0 && _isAttackFireball)
        {
            _nextFireTime = _cooldown;
            FireballShooting?.Invoke();
            _animation.PlayAttackPlayer(_isAttackFireball);
            _isAttackFireball = false;
        }
    }

    private void ResetAttack()
    {
        _animation.PlayAttackPlayer(_isAttackFireball);
        _isAttackFireball = true;
    }
}
