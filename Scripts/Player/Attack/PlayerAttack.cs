using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _cooldown = 2f;

    private InitAnimation _animation;
    private AnimationAttackEvents _events;

    private float _nextFireTime;
    private bool _isAttackFireball = true;

    public event Action FireballShooting;
    public event Action AuraActivating;

    private void Awake()
    {
        _animation = GetComponent<InitAnimation>();
        _events = GetComponent<AnimationAttackEvents>();
    }

    private void Update()
    {
        ShootFireball();
        UseVampirismSkill();
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

    private void UseVampirismSkill()
    {
        if (InputService.SetKeyCode(InputService.KeyR))
        {
            AuraActivating?.Invoke();
        }
    }

    private void ResetAttack()
    {
        _animation.PlayAttackPlayer(_isAttackFireball);
        _isAttackFireball = true;
    }
}
