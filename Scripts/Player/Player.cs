using UnityEngine;

public class Player : MonoBehaviour
{
    private Health _healht;

    private void Awake()
    {
        _healht = GetComponent<Health>();
    }

    public void Hit(float damage)
    {
        _healht.TakeDamage(damage);
    }

    public void Heal(float amountHeal)
    {
        _healht.TakeHeal(amountHeal);
    }
}
