using System;
using UnityEngine;

public class SlimeAttack_S : State
{
    private EnemyMovement _movement;
    private Transform _attackPoint;

    private Action AttackAction;
    private Action CanSwitchAction;

    private bool _canSwitch = false;

    public SlimeAttack_S(ContainerForEnemyComponents components, Transform attackPoint) : base(components) {
        _movement = new EnemyMovement(components);
        _attackPoint = attackPoint;

        AttackAction = TryAttack;
        CanSwitchAction = CanSwitchState;
    }

    public override void Enter() {
        base.Enter();
        _components.Animator.SetBool("IsAttack", true);
        _components.AnimationEvents.OnAttack += AttackAction;
        _components.AnimationEvents.OnEndAttack += CanSwitchAction;
        _canSwitch = false;
    }

    public override void Update() {
        _movement.RotaeToTarget();
        if (_canSwitch) {
            base.Update();
        }    
    }

    public override void FixedUpdate() {

    }

    public override void Exit() {
        base.Exit();
        _components.Animator.SetBool("IsAttack", false);
        _components.AnimationEvents.OnAttack -= AttackAction;
        _components.AnimationEvents.OnEndAttack -= CanSwitchAction;
    }

    private void TryAttack() {
        _canSwitch = false;

        RaycastHit hit;
        Ray ray = new Ray(_attackPoint.position, _attackPoint.forward);

        if (Physics.SphereCast(ray, 0.5f, out hit, 2f, _components.PlayerLayerId)) {
            Debug.Log(hit.transform.name);
            PlayerController player = hit.transform.GetComponent<PlayerController>();
            player.TakeDamage(_components.Settings.Damage);
        }
    }

    private void CanSwitchState() {
        _canSwitch = true;
    }
}
