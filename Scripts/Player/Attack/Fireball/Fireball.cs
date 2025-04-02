using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _damage = 50f;

    private Enemy _enemy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy = enemy;
            DealDamage();
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            _enemy = null;
        }
    }

    private void DealDamage()
    {
        if(_enemy != null)
        {
            _enemy.Hit(_damage);
        }
    }
}
