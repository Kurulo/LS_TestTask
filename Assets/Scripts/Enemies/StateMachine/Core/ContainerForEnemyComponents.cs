using UnityEngine;

public class ContainerForEnemyComponents
{
    public StateMachine CurrentStateMachine {  get; private set; }
    public EnemySettings_SO Settings { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public int PlayerLayerId { get; private set; }
    public AnimationEventReceiver AnimationEvents { get; private set; }
    public CollisionDetectionHandler CollisionDetectionHandler { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public Transform Transform { get; private set; }
    public Animator Animator { get; private set; }
    public HealthSystem HealthSytem { get; private set; }

    public ContainerForEnemyComponents(StateMachine currentStateMachine, EnemySettings_SO settings, PlayerController player) {
        CurrentStateMachine = currentStateMachine;
        Settings = settings;
        PlayerController = player;

        Transform = CurrentStateMachine.transform;
        GetComponents();
    }

    private void GetComponents() {
        HealthSytem = new HealthSystem(Settings.Health);

        PlayerLayerId = 1 << PlayerController.gameObject.layer;
        Rigidbody = Transform.GetComponent<Rigidbody>();
        AnimationEvents = Transform.GetComponentInChildren<AnimationEventReceiver>();
        Animator = Transform.GetComponentInChildren<Animator>();
        CollisionDetectionHandler = Transform.GetComponentInChildren<CollisionDetectionHandler>();
    }
}
