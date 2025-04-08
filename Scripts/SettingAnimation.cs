using UnityEngine;

[RequireComponent(typeof(Animator))]

public class SettingAnimation : MonoBehaviour
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

    public void PlayEnemyAttack()
    {
        _animator.SetTrigger(AnimationData.Attack);
    }

    public void ResetEnemyAttack() 
    {
        _animator.SetTrigger(AnimationData.ResetAttack);
    }

    public void PlayAttackPlayer(bool isAttack)
    {
        _animator.SetBool(AnimationData.AttackPlayer,isAttack);
    }
}
