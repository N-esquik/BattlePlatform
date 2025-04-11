using UnityEngine;

[RequireComponent(typeof(Aura))]

public class EnemyDetector : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayerMask;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _detectionRadius;

    private Collider2D[] _collidersBuffer = new Collider2D[5];

    public Health UpdateEnemiesInRange()
    {
        Health nearest = null;
        float minDistance = float.MaxValue;
    
        int count = Physics2D.OverlapCircleNonAlloc(transform.position - _offset, _detectionRadius, _collidersBuffer, _enemyLayerMask);
    
        for (int i = 0; i < count; i++)
        {
            if (_collidersBuffer[i].gameObject.TryGetComponent(out Health enemy))
            {
                float distance = VectorExtensions.SqrDistance(transform.position, _collidersBuffer[i].transform.position);
                
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }
        }
    
        return nearest;
    }
}

