using UnityEngine;

[RequireComponent (typeof(PlayerAttack))]

public class SpawnerFireball : MonoBehaviour
{
    [SerializeField] private Fireball _prefab;
    [SerializeField] private Transform _positionFireball;

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

    private Fireball CreateFireboll()
    {
        return Instantiate(_prefab, _positionFireball.position, Quaternion.identity);
    }

    private void ShootFireball()
    {
        Fireball fireball =  CreateFireboll();
        fireball.Init(_positionFireball.right);
    }
}
