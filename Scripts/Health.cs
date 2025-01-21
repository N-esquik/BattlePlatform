using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentValue = 100f;

    private float _maxValue = 100f;

    public event Action<float, float> ValueChanged;

    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    public bool IsDead => _currentValue <= 0;

    public void TakeHeal(float amountHeal)
    {
        _currentValue += amountHeal;
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
        NotifyValueChanged();
    }

    public void TakeDamage(float damage)
    {
        if (IsDead)
            return;

        _currentValue -= damage;
        _currentValue = Mathf.Clamp(_currentValue, 0f, _maxValue);
        NotifyValueChanged();
    }

    private void NotifyValueChanged()
    {
        ValueChanged?.Invoke(_currentValue, _maxValue);
    }
}
