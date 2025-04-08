using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(SpawnerAura))]
[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(EnemyDetector))]

public class Aura : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _offsetAura;

    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _interval = 1f;

    [SerializeField] private Health _damageToTheEnemy;
    [SerializeField] private Health _healingToTheOwner;

    private EnemyDetector _enemyDetector;
    private SpawnerAura _spawner;
    private SliderAura _slider;

    private float _attackInterval;
    private float _durationSpell = 6f;
    private float _cooldownSpell;
    private bool _isActiveSpell;

   public GameObject GameObject => _prefab;

    private void Awake()
    {
        _spawner = GetComponent<SpawnerAura>();
        _slider = GetComponent<SliderAura>();
        _enemyDetector = GetComponent<EnemyDetector>();
    }

    private void Start()
    {
        _prefab = _spawner.Create(_prefab, transform);
        _prefab.SetActive(_isActiveSpell);
    }

    private void Update()
    {
        if (_isActiveSpell)
        {
            FollowThePlayer();

            _durationSpell -= Time.deltaTime;
            _slider.ShowDuration(_duration, _durationSpell);

            Attack();

            if (_durationSpell <= 0)
            {
                DeactivateSpell();
            }
        }
        else if (_durationSpell <= 0)
        {
            _cooldownSpell -= Time.deltaTime;
            _slider.ShowCooldown(_cooldown, _cooldownSpell);

            if (_cooldownSpell <= 0)
            {
                _cooldownSpell = 0;
                _slider.IsActive(_isActiveSpell);
            }
        }
    }

    public void ActivateAura()
    {
        if (_prefab != null && _cooldownSpell <= 0)
        {
            ActivateSpell();
        }
    }

    public void ApplyDamageAndHeal(Health enemy)
    {
        enemy.TakeDamage(_damage);
        _healingToTheOwner.TakeHeal(_damage);
    }

    private void FollowThePlayer()
    {
        if (_prefab != null && _isActiveSpell == true)
        {
            _prefab.transform.position = transform.position - _offsetAura;
        }
    }

    private void Attack()
    {
        _attackInterval -= Time.deltaTime;

        if (_attackInterval <= 0)
        {
            _enemyDetector.UpdateEnemiesInRange();
            _attackInterval = _interval;
        }
    }

    private void ActivateSpell()
    {
        if (_cooldownSpell <= 0)
        {
            _isActiveSpell = true;
            _prefab.SetActive(_isActiveSpell);
            _slider.IsActive(_isActiveSpell);
            _durationSpell = _duration;
            _cooldownSpell = _cooldown;
        }
    }

    private void DeactivateSpell()
    {
        _isActiveSpell = false;

        _prefab.SetActive(_isActiveSpell);
    }
}
