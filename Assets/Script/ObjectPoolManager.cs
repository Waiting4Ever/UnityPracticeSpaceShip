using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public ObjectPool[] pools;
    Dictionary<string, ObjectPool> _pools;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        _pools = new Dictionary<string, ObjectPool>();

        foreach (ObjectPool pool in pools)
        {
            pool.Init(transform);
            _pools.Add(pool.pooledObject.name, pool);
        }

        Debug.Log("[ObjectPoolManager::Start] _pools.Count = " + _pools.Count);
    }

    public GameObject GetObject(string ID, bool activate = false, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
    {
        if (!_pools.ContainsKey(ID))
        {
            Debug.Log("[ObjectPoolManager::GetObject] pool " + ID + " don't exist!");
            return null;
        }

        GameObject obj = _pools[ID].GetObject();

        if (obj == null)
        {
            Debug.Log("[ObjectPoolManager::GetObject] " + ID + " pool not big enough!");
            return null;
        }

        obj.transform.position = position;
        obj.transform.rotation = rotation;

        if (activate)
            obj.SetActive(true);

        return obj;
    }
}
