using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachine : MonoBehaviour, IDamageable
{
    private State _curentState;

    protected ContainerForEnemyComponents _components;
    public ContainerForEnemyComponents Componets { get { return _components; } }

    private void Update() {
        if (_curentState != null) {
            _curentState.Update();
        }
    }

    private void FixedUpdate() {
        if (_curentState != null) { 
            _curentState.FixedUpdate();
        }
    }

    private void SetState(State state) {
        _curentState?.Exit();
        _curentState = state;
        _curentState.Enter();
    }

    protected void Init(State initialState, Dictionary<State, Dictionary<Transition, State>> states) {
        foreach (var state in states) {
            foreach (var transition in state.Value) {
                transition.Key.Callback = () => SetState(transition.Value);
                state.Key.AddTransition(transition.Key);
            }
        }

        SetState(initialState);
    }

    public virtual void TakeDamage(float amount) {
        
    }
}
