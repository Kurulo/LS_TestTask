using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SlimeEmergance_S : State
{
    private bool _canSwitch = false;
    private Vector3 _orginalScale;

    public SlimeEmergance_S(ContainerForEnemyComponents components) : base(components) {

    }

    public override void Enter() {
        base.Enter();
        _canSwitch = false;
        _orginalScale = _components.Transform.localScale;
        _components.Transform.localScale = Vector3.zero;
    }

    public override void Update() {
        _components.Transform.DOScale(_orginalScale, 1f).OnComplete(() => {
            _canSwitch = true;
        });

        if (_canSwitch) {
            base.Update();
        }
    }

    public override void FixedUpdate() {

    }

    public override void Exit() {
        base.Exit();
    }
}
