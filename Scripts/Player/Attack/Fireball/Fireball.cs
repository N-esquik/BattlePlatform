using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _damage = 50f;
    [SerializeField] private float _speed = 1f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.Hit(_damage);
            Destroy(gameObject);
        }
    }

    public void Init(Vector2 direction)
    {
        _rigidbody.velocity = direction * _speed;
    }
}
