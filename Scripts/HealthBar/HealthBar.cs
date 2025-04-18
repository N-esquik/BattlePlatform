using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;
    private WaitForSecondsRealtime _wait;

    private float _interval = 0.0001f;
    private float _speedMoveSlider = 50f;

    private void Start()
    {
        _healthBar.maxValue = _health.MaxValue;
        _healthBar.value = _health.CurrentValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += ShowInfo;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ShowInfo;
    }

    private void ShowInfo(float currentHealth, float maxHealth)
    {
        if (_health != null)
        {
            StopPreviousCoruotine();
            _coroutine = StartCoroutine(MoveHealthBar(currentHealth, maxHealth));
        }
    }

    private IEnumerator MoveHealthBar(float currentHealth, float maxHealth)
    {
        _healthBar.maxValue = maxHealth;
        _wait = new WaitForSecondsRealtime(_interval);

        while (currentHealth != _healthBar.value)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, currentHealth, _speedMoveSlider * Time.deltaTime);
            yield return _wait;
        }
    }

    private void StopPreviousCoruotine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
