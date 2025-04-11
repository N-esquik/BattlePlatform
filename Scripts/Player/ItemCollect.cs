using UnityEngine;

[RequireComponent (typeof(Health))]

public class ItemCollect : MonoBehaviour
{
    private Health _health;
    private int _healthRegenPotion = 75;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Potion potion))
        {
            _health.TakeHeal(_healthRegenPotion);
            Destroy(potion.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Potion potion)) { }
    }
}
