using UnityEngine;

public class HealthBarFollowMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;

    private Vector3 _lastPosition;

    private void Start()
    {
        _lastPosition = _target.position;
    }

    private void Update()
    {
        if(_target.position != _lastPosition)
        {
            transform.position = _target.position + _offset;

            _lastPosition = _target.position;
        }
    }
}