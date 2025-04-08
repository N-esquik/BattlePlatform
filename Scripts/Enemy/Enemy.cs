using UnityEngine;

[RequireComponent(typeof(Health))]

public class Enemy : MonoBehaviour
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
}
