using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [Header("Weapon Settings")]
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackInterval;

    public float Damage { get { return _damage; } set { _damage = value; } }

    protected bool _isReadyToUse;
    public bool IsReadyToUse { get { return _isReadyToUse; } }

    protected PlayerCombatSystem _owner;

    public void SetOwner(PlayerCombatSystem owner) {
        if (_owner == null) {
            _owner = owner;
        }

        _isReadyToUse = false;
    }

    public virtual void UseWeapon() {

    }
}
