using UnityEngine;
using UnityEngine.Events;

public class CollisionDetectionHandler : MonoBehaviour
{
    private UnityEvent<GameObject> _triggerEvent = new UnityEvent<GameObject>();
    private UnityEvent<GameObject> _collisionEvent = new UnityEvent<GameObject>();

    private void OnTriggerEnter(Collider other) {
        _triggerEvent?.Invoke(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        _collisionEvent?.Invoke(collision.gameObject);
    }

    public bool HasListener() {
        return _triggerEvent == null;
    }

    public void AddCollisionListener(UnityAction<GameObject> action) {
        _collisionEvent.AddListener(action);
    }

    public void RemoveCollisionListener(UnityAction<GameObject> action) {
        _collisionEvent.RemoveListener(action);
    }

    public void AddTriggerListener(UnityAction<GameObject> action) {
        _triggerEvent.AddListener(action);
    }

    public void RemoveTriggerListener(UnityAction<GameObject> action) {
        _triggerEvent.RemoveListener(action);
    }
}
