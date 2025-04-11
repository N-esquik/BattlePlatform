using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue = 200f;
    [SerializeField] private float _maxValue = 200f;

    public event Action<float, float> ValueChanged;
    public event Action HealthChanged;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;
    public bool IsDead => _currentValue <= 0;

    public void TakeHeal(float amountHeal)
    {
        if (amountHeal > 0)
        {
            _currentValue += amountHeal;
            _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
            NotifyValueChanged();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _currentValue -= damage;
            _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
            NotifyValueChanged();
        }

        if (IsDead)
            HealthChanged?.Invoke();
    }

    private void NotifyValueChanged()
    {
        ValueChanged?.Invoke(_currentValue, _maxValue);
    }
}
