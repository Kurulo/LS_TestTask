using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class PoolOfObjects<T>
{
    private T _poolableObject;
    private GameObject _poolableGO;
    [SerializeField] private List<T> _pool = new List<T>();

    private bool _activeByDeafult;
    private bool _instantiateByDeafult;
    private int _maxPoolSize;

    public void SetActiveByDefault(bool value) {
        _activeByDeafult = value; 
    }

    public void PoolSetup(T poolableObject, GameObject poolableGO, int maxPoolSize, bool activeBuDefault = false) {
        _poolableObject = poolableObject;
        _poolableGO = poolableGO;
        _maxPoolSize = maxPoolSize;
        _activeByDeafult = activeBuDefault;
    }

    public void FillPool(int amount = 10) {
        CreateFewObjectsInPool(amount);
        Debug.Log("Object in pool: " + _pool.Count);
    }

    public T TryGetObjectFromPool() {
        if (_pool.Count > 0) {
            return GetLast();
        }
        else {
            CreateFewObjectsInPool(1);
            return GetLast();
        }
    }

    public void AddToPool(T poolableObject) {
        _pool.Add(poolableObject);
    }

    public void RemoveObjectWithId(int id) {
        _pool.RemoveAt(id);
    }

    public int GetCurrentPoolCount() {
        return _pool.Count;
    }

    public void CreateFewObjectsInPool(int amount) {
        for (int i = 0; i < amount; i++) {
            var obj = UnityEngine.Object.Instantiate(_poolableGO);
            obj.SetActive(_activeByDeafult);

            AddToPool(obj.GetComponent<T>());
        }
    }

    private T GetLast() {
        T last = _pool[_pool.Count - 1];
        RemoveObjectWithId(_pool.Count - 1);
        return last;
    }
}
