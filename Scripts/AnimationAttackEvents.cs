using System;
using UnityEngine;

public class AnimationAttackEvents : MonoBehaviour
{
    public event Action Attacked;
    public event Action ResetAttacked;
    public event Action ResetPlayerAttacked;

    public void InvokeAttackingEvent() => Attacked?.Invoke();

    public void InvokeResetAttackEvent() => ResetAttacked?.Invoke();

    public void InvokeResetAttackEventPlayer() => ResetPlayerAttacked?.Invoke();
}

