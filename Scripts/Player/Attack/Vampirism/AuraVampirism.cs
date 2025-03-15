using UnityEngine;
using UnityEngine.UI;

public class AuraVampirism : MonoBehaviour
{
    [SerializeField] private float _cooldown = 4f;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _interval = 1f;

    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private Player _player;
    [SerializeField] private AuraVampirism _auraVampirism;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _prefabAura;
    [SerializeField] private Vector3 _offsetAura;
    [SerializeField] private Vector3 _offsetSlider;

    private Enemy _enemy;
    private GameObject _aura;

    private float _maxValueSlider = 1f;
    private float _attackInterval;
    private float _cooldownSpell;
    private float _durationSpell;

    private bool _isActiveSpell;
    private bool _isCollidingWithPlayer = false;

    private void Awake()
    {
        _slider.maxValue = _maxValueSlider;
        _slider.gameObject.SetActive(_isActiveSpell);
    }

    private void Update()
    {
        if (_slider != null)
        {
            _slider.transform.position = transform.position + _offsetSlider;
        }

        if (_isActiveSpell)
        {
            FollowThePlayer();
            _slider.gameObject.SetActive(_isActiveSpell);

            _durationSpell -= Time.deltaTime;
            _slider.value = _durationSpell / _duration;

            Attack();

            if (_durationSpell <= 0)
            {
                DeactivateSpell();
            }
        }
        else
        {
            _cooldownSpell -= Time.deltaTime;
            _slider.value = _maxValueSlider - (_cooldownSpell / _cooldown);

            if (_cooldownSpell <= 0)
            {
                _cooldownSpell = 0;
                _slider.gameObject.SetActive(_isActiveSpell);
            }
        }
    }

    private void OnEnable()
    {
        _playerAttack.AuraActivating += ActivateSpell;
    }

    private void OnDisable()
    {
        _playerAttack.AuraActivating -= ActivateSpell;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
            _isCollidingWithPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy = null;
            _isCollidingWithPlayer = false;
        }
    }

    private void Attack()
    {
        _attackInterval -= Time.deltaTime;

        if (_enemy != null && _attackInterval <= 0 && _isCollidingWithPlayer)
        {
            _enemy.Hit(_damage);
            _player.Heal(_damage);
            _attackInterval = _interval;
        }
    }

    public void ActivateSpell()
    {
        if (_cooldownSpell <= 0)
        {
            _aura = Instantiate(_prefabAura, transform.position - _offsetAura, Quaternion.identity);

            _isActiveSpell = true;
            _durationSpell = _duration;
            _cooldownSpell = _cooldown;
        }
    }

    private void FollowThePlayer()
    {
        if (_aura != null)
        {
            _aura.transform.position = transform.position - _offsetAura;
        }
    }

    private void DeactivateSpell()
    {
        _isActiveSpell = false;

        if (_aura != null)
        {
            Destroy(_aura);
        }
    }
}
