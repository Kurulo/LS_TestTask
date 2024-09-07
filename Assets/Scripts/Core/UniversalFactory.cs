using UnityEngine;
using Zenject;

public class UniversalFactory
{
    private DiContainer _diContainer;

    private UniversalFactory(DiContainer diContainer) {
        _diContainer = diContainer;
    }

    public T Create<T>(Object prefab) {
        return _diContainer.InstantiatePrefabForComponent<T>(prefab);
    }

    public T Create<T>(Object prefab, Transform parent) {
        return _diContainer.InstantiatePrefabForComponent<T>(
            prefab,
            parent);
    }

    public T Create<T>(Object prefab, Vector3 position, Quaternion rotation, Transform parent) {
        return _diContainer.InstantiatePrefabForComponent<T>(
            prefab,
            position,
            rotation,
            parent);
    }

    public GameObject Create(Object prefab) {
        return _diContainer.InstantiatePrefab(prefab);
    }

    public GameObject Create(Object prefab, Transform parent) {
        return _diContainer.InstantiatePrefab(
            prefab,
            parent);
    }

    public GameObject Create(Object prefab, Vector3 position, Quaternion rotation, Transform parent) {
        return _diContainer.InstantiatePrefab(
            prefab,
            position,
            rotation,
            parent);
    }
}
