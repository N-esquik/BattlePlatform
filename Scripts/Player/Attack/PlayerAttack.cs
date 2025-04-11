using System;
using UnityEngine;

[RequireComponent(typeof(SettingAnimation))]
[RequireComponent(typeof(AnimationAttackEvents))]
[RequireComponent(typeof(Aura))]
[RequireComponent(typeof(UserInput))]

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _cooldown = 2f;

    private SettingAnimation _animation;
    private AnimationAttackEvents _events;
    private UserInput _userInput;
    private Aura _aura;

    private float _nextFireTime;
    private bool _isAttackFireball = true;

    public event Action FireballShooting;

    private void Awake()
    {
        _animation = GetComponent<SettingAnimation>();
        _events = GetComponent<AnimationAttackEvents>();
        _aura = GetComponent<Aura>();
        _userInput = GetComponent<UserInput>();
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

        if (_userInput.SetKeyCode(UserInput.KeySpace) && _nextFireTime <= 0 && _isAttackFireball)
        {
            _nextFireTime = _cooldown;
            FireballShooting?.Invoke();
            _animation.PlayAttackPlayer(_isAttackFireball);
            _isAttackFireball = false;
        }
    }

    private void UseVampirismSkill()
    {
        if (_userInput.SetKeyCode(UserInput.KeyR))
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
