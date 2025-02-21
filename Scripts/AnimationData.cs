using UnityEngine;

public static class AnimationData
{
    public static readonly int Speed = Animator.StringToHash(nameof(Speed));

    public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    public static readonly int ResetAttack = Animator.StringToHash(nameof(ResetAttack));

    public static readonly int AttackPlayer = Animator.StringToHash(nameof(AttackPlayer));
}
