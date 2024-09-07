using UnityEngine;

public abstract class DistanceToTarget : Transition
{
    private Transform _origin;
    private Transform _target;

    public DistanceToTarget(Transform origin, Transform target) {
        _origin = origin;
        _target = target;
    }

    protected float CheckDistanceToTarget(Vector3 target) => Vector3.Distance(_origin.position, target);
    private Vector3 _targetPos => _target.position;
    protected float _distance => Vector3.Distance(_origin.position, _targetPos);
}
