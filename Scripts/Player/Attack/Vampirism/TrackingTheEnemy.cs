using System.Collections.Generic;
using UnityEngine;

public class TrackingTheEnemy : MonoBehaviour
{
    private List<Health> _enemiesInRange = new List<Health>();

    private Aura _aura;

    private void Awake()
    {
        _aura = GetComponent<Aura>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Health enemy))
        {
            if (!_enemiesInRange.Contains(enemy))
            {
                _enemiesInRange.Add(enemy);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out Health enemy))
        {
            if (_enemiesInRange.Contains(enemy))
            {
                _enemiesInRange.Remove(enemy);
            }
        }
    }

    public void FindEnemies()
    {
        var enemiesCopy = new List<Health>(_enemiesInRange);

        foreach (var enemy in enemiesCopy)
        {
            _aura.ApplyDamageAndHeal(enemy);
        }
    }
}

