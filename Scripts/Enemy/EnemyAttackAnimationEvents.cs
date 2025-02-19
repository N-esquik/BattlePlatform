using System;
using UnityEngine;

public class EnemyAttackAnimationEvents : MonoBehaviour
{
    public event Action Attacked;
    public event Action ResetAttacked;

    public void InvokeAttackingEvent() => Attacked?.Invoke();

    public void InvokeResetAttackEvent() => ResetAttacked?.Invoke();
}
