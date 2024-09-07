using UnityEngine;

public class InChasingRange_T : DistanceToTarget
{
    private ContainerForEnemyComponents _components;

    public InChasingRange_T(ContainerForEnemyComponents components, Transform origin, Transform target) : base(origin, target) {
        _components = components;
    }

    public override bool CheckCondition() {
        return _distance > _components.Settings.ChasingRange;
    }
}
