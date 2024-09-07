using System;
using System.Collections;
using UnityEngine;


public class SlimeDeath_S : State
{
    private Action DeathAction;

    public SlimeDeath_S(ContainerForEnemyComponents components) : base(components) {
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("Enemy Dead");
        _components.Animator.SetTrigger("Dead");

        if (DeathAction == null) {
            DeathAction = Death;
        }

        _components.AnimationEvents.OnEndDeath = DeathAction;
    }
    public override void Update() {
        base.Update();
    }

    public override void FixedUpdate() {
        
    }

    public override void Exit() {
        base.Exit();
    }

    private void Death() {
        _components.Animator.ResetTrigger("Dead");
        _components.Transform.gameObject.SetActive(false);
    }
}
