
public class SlimeChasing_S : State
{
    private EnemyMovement _movement;

    public SlimeChasing_S(ContainerForEnemyComponents components) : base(components) {
        _movement = new EnemyMovement(components);
    }

    public override void Enter() {
        base.Enter();
        _components.Animator.SetBool("IsChasing", true);
    }

    public override void Update() {
        base.Update();     
        _movement.RotaeToTarget();
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
        _movement.MoveToTarget();
    }

    public override void Exit() {
        base.Exit();
        _components.Animator.SetBool("IsChasing", false);
    }
}
