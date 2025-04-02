using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damage = 40;
    [SerializeField] private float _cooldown = 3f;

    private InitAnimation _enemyAnimation;
    private AnimationAttackEvents _enemyAttackAnimationEvents;
    private EnemyChase _enemyChase;
    private Player _player;

    private float _cooldownTime;
    private bool _isAttack = true;
    private bool _isCollidingWithPlayer = false;

    private void Awake()
    {
        _enemyAnimation = GetComponent<InitAnimation>();
        _enemyAttackAnimationEvents = GetComponent<AnimationAttackEvents>();
        _enemyChase = GetComponent<EnemyChase>();  
    }

    private void Update()
    {
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
        }

        if (CanPerformAttack())
        {
            TryAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            _player = player;
            _isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Player player))
        {
            _isCollidingWithPlayer = false;
            _player = null;
        }
    }

    private void OnEnable()
    {
        _enemyAttackAnimationEvents.Attacked += DealDamage;
        _enemyAttackAnimationEvents.ResetAttacked += ResetAttack;
    }

    private void OnDisable()
    {
        _enemyAttackAnimationEvents.Attacked -= DealDamage;
        _enemyAttackAnimationEvents.ResetAttacked -= ResetAttack;
    }

    private void TryAttack()
    {
        if (CanPerformAttack())
        {
            _enemyAnimation.PlayEnemyAttack();
            _isAttack = false;
        }
    }

    private bool CanPerformAttack()
    {
        return _isCollidingWithPlayer && _cooldownTime <= 0 && _isAttack;
    }

    private void DealDamage()
    {
        if (_player != null)
        {
            _player.Hit(_damage);
        }
    }

    private void ResetAttack()
    {
        _enemyAnimation.ResetEnemyAttack();
        _cooldownTime = _cooldown;
        _isAttack = true;
    }
}
