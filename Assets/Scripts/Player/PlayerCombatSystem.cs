using UnityEngine;

public class PlayerCombatSystem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Weapon _startWeapon;
    [SerializeField] private LayerMask _enemyLayer;

    public LayerMask EnemyLayer => _enemyLayer;
    private Weapon _currentWeapon;

    private void Start() {
        if (_startWeapon != null) { 
            _currentWeapon = _startWeapon;
            _currentWeapon.SetOwner(this);
        }
    }

    private void Update() {
        if (_currentWeapon.IsReadyToUse) {
            _currentWeapon.UseWeapon();
        }
    }

    public StateMachine GetNearestEnemyInRadius(float radius) {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, radius,
            Vector3.up, 0f, _enemyLayer);

        StateMachine nearestEnemy = null;
        float nearestDistanceSqr = Mathf.Infinity;

        if (hits.Length > 0) {
            foreach (RaycastHit hit in hits) {
                float distanceSqr = (transform.position - hit.transform.position).sqrMagnitude;
                if (distanceSqr < nearestDistanceSqr) {
                    nearestDistanceSqr = distanceSqr;
                    nearestEnemy = hit.transform.GetComponent<StateMachine>();
                }
            }
        }

        return nearestEnemy;
    }
}
