using UnityEngine;
using Zenject;

public class SlimeEnemy_SM : StateMachine
{
    [Header("References")]
    [SerializeField] private EnemySettings_SO _settigs;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private ParticleSystem _hitParticle;

    private PlayerController _playerController;

    [Inject]
    private void Construct(PlayerController player) {
        _playerController = player;
    }

    private void OnEnable() {
        if (_components == null) {
            SetupEnemy();
        } else {
            ResetupEnemy();
        }

        // Transitions
        Transition inChasingRange = new InChasingRange_T(_components, transform, _playerController.transform);
        Transition inAttackRantge = new InAttackRange_T(_components, transform, _playerController.transform);
        Transition isDead = new IsDead_T(_components);

        // State 
        State chasingState = new SlimeChasing_S(_components);
        State attackState = new SlimeAttack_S(_components, _attackPoint);
        State deadState = new SlimeDeath_S(_components);
        State emerganceState = new SlimeEmergance_S(_components);   

        Init(emerganceState, new () 
        {
            {emerganceState, new () {
                {inChasingRange, chasingState }
            } },
            { chasingState, new ()
            {
                {isDead, deadState },
                {inAttackRantge, attackState }
            }},
            { attackState, new ()
            {
                {isDead, deadState },
                { inChasingRange, chasingState }
            }}
        }); 
    }

    private void SetupEnemy() {
        _components = new ContainerForEnemyComponents(this, _settigs, _playerController);
    }

    private void ResetupEnemy() {
        _components.HealthSytem.ResetHealth();
    }

    public override void TakeDamage(float amount) {
        _hitParticle.Play();
        _components.HealthSytem.DecreasHealth(amount);
    }
}
