using UnityEngine;

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

    private TrackingTheEnemy _trackingTheEnemy;
    private SpawnerAura _spawner;
    private SliderAura _slider;
    private GameObject _gameObject;

    private float _attackInterval;
    private float _durationSpell = 6f;
    private float _cooldownSpell;
    private bool _isActiveSpell;

    public GameObject GameObject => _gameObject;

    private void Awake()
    {
        _spawner = GetComponent<SpawnerAura>();
        _slider = GetComponent<SliderAura>();
        _trackingTheEnemy = GetComponent<TrackingTheEnemy>();
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
        if (_gameObject == null && _cooldownSpell <= 0)
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
        if (_gameObject != null)
        {
            _gameObject.transform.position = transform.position - _offsetAura;
        }
    }

    private void Attack()
    {
        _attackInterval -= Time.deltaTime;

        if (_attackInterval <= 0)
        {
            _trackingTheEnemy.FindEnemies();
            _attackInterval = _interval;
        }
    }

    private void ActivateSpell()
    {
        if (_cooldownSpell <= 0)
        {
            _gameObject = _spawner.Create(_prefab,transform);
            _isActiveSpell = true;
            _slider.IsActive(_isActiveSpell);
            _durationSpell = _duration;
            _cooldownSpell = _cooldown;
        }
    }

    private void DeactivateSpell()
    {
        _isActiveSpell = false;

        if (_gameObject != null)
        {
            Destroy(_gameObject);
        }
    }
}
