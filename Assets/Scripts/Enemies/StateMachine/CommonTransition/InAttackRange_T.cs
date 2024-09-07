using UnityEngine;

public class InAttackRange_T : DistanceToTarget
{
    private ContainerForEnemyComponents _components;

    public InAttackRange_T(ContainerForEnemyComponents components, Transform origin, Transform target) : base(origin, target) {
        _components = components;
    }

    public override bool CheckCondition() {
        return _distance < _components.Settings.AttackRange;
    }
}
