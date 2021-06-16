using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make this class visible in the inspector
[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
}

public class Pool : MonoBehaviour
{
    public static Pool singleton;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;    
    }

    public GameObject Get(string tag)
    {
        // Search for all items in the pool
        for (int i = 0; i < pooledItems.Count; i++)
        {
            // Find and return the objects which are inactive and has the same tag
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }

        // No object in the pool is availble for use at the moment
        return null;
    }


    // Start is called before the first frame update
    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                // Objects in pool should remain inactive in the hierarachy
                // This will make sure the object will not be using memory
                // Use this object only if he is inactive
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
