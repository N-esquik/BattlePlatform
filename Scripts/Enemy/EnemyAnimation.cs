using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(float speed)
    {
        _animator.SetFloat(AnimationData.Speed, Mathf.Abs(speed));
    }
}
