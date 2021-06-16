using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 2)
        {
            GameObject asteroid = Pool.singleton.Get("Asteroid");
            if (asteroid != null)
            {
                asteroid.transform.position = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                asteroid.SetActive(true);
            }     
        }       
    }
}
