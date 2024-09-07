using UnityEngine;

public class IsDead_T : Transition
{
    private ContainerForEnemyComponents _components;

    public IsDead_T(ContainerForEnemyComponents components) { 
        _components = components;
    }

    public override bool CheckCondition() {
        return _components.HealthSytem.IsDead();
    }
}
