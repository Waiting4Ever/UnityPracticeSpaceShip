using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    public GameObject pooledObject;
    public int maxSize;

    GameObject[] pool;

    public void Init(Transform parent)
    {
        pool = new GameObject[maxSize];

        for (int i = 0; i < maxSize; i++)
        {
            pool[i] = GameObject.Instantiate(pooledObject) as GameObject;
            pool[i].transform.parent = parent;
            pool[i].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pool.Length; i++)
            if (!pool[i].activeSelf)
                return pool[i];

        return null;
    }
}
