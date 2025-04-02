using UnityEngine;

public class SpawnerFireball : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _positionFireball;
    [SerializeField] private float _speedFireball = 1f;

    private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack = GetComponent<PlayerAttack>();
    }

    private void OnEnable()
    {
        _playerAttack.FireballShooting += ShootFireball;
    }

    private void OnDisable()
    {
        _playerAttack.FireballShooting -= ShootFireball;
    }

    private GameObject CreateFireboll()
    {
        return Instantiate(_prefab, _positionFireball.transform.position, Quaternion.identity);
    }

    private void ShootFireball()
    {
        GameObject fireball =  CreateFireboll();
        Rigidbody2D rigidbody = fireball.GetComponent<Rigidbody2D>();
        rigidbody.velocity = _positionFireball.right * _speedFireball;
    }
}
