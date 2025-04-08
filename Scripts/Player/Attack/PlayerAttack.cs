using System;
using UnityEngine;

[RequireComponent(typeof(SettingAnimation))]
[RequireComponent(typeof(AnimationAttackEvents))]
[RequireComponent(typeof(Aura))]

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _cooldown = 2f;

    private SettingAnimation _animation;
    private AnimationAttackEvents _events;
    private Aura _aura;

    private float _nextFireTime;
    private bool _isAttackFireball = true;

    public event Action FireballShooting;

    private void Awake()
    {
        _animation = GetComponent<SettingAnimation>();
        _events = GetComponent<AnimationAttackEvents>();
        _aura = GetComponent<Aura>();
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
            _aura.ActivateAura();
        }
    }

    private void ResetAttack()
    {
        _animation.PlayAttackPlayer(_isAttackFireball);
        _isAttackFireball = true;
    }
}
