using UnityEngine;

[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    private Health _healht;

    private void Awake()
    {
        _healht = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _healht.HealthChanged += Die;
    }
    
    private void OnDisable()
    {
        _healht.HealthChanged -= Die;
    }

    public void Hit(float damage)
    {
        _healht.TakeDamage(damage);
    }

    public void Heal(float amountHeal)
    {
        _healht.TakeHeal(amountHeal);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
