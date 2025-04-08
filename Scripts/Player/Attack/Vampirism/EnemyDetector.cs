using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Aura))]

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _detectionRadius;

    private List<Health> _enemiesInRange = new List<Health>();
    private Collider2D[] _collidersBuffer = new Collider2D[5];

    private Aura _aura;

    private void Awake()
    {
        _aura = GetComponent<Aura>();
    }

    public void UpdateEnemiesInRange()
    {
        _enemiesInRange.Clear();

        int count = Physics2D.OverlapCircleNonAlloc(transform.position - _offset, _detectionRadius,_collidersBuffer,_enemyLayerMask);

        for (int i = 0; i < count; i++)
        {
            if(_collidersBuffer[i].gameObject.TryGetComponent(out Health enemy))
            {
                if (!_enemiesInRange.Contains(enemy))
                {
                    _enemiesInRange.Add(enemy);
                    _aura.ApplyDamageAndHeal(enemy);
                }
            }
        }
    }
}

