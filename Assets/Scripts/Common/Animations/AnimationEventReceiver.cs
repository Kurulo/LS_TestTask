using System;
using UnityEngine;

public class AnimationEventReceiver : MonoBehaviour
{
    [HideInInspector]
    public Action OnAttack;
    [HideInInspector]
    public Action OnStep;
    [HideInInspector]
    public Action OnEndDeath;
    [HideInInspector]
    public Action OnEndAttack;
    [HideInInspector]
    public Action OnDeath;
    [HideInInspector]
    public Action OnPlayParticle;

    public void OnAttackEvent() {
        OnAttack?.Invoke();
    }

    public void OnStepEvent() {
        OnStep?.Invoke();
    }
    public void OnEndDeathEvent() {
        OnEndDeath?.Invoke();
    }

    public void OnEndAttackEvent() {
        OnEndAttack?.Invoke();
    }

    public void OnDeathEvent() {
        OnDeath?.Invoke();
    }

    public void OnPlayParticleEvent() {
        OnPlayParticle?.Invoke();
    }
}
