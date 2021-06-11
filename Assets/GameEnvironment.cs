using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sealed - this class can't be used to create other classes
// No other classes can inherit from this class
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();

    public List<GameObject> Obstacles { get { return obstacles; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
            }

            return instance;
        }
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
    }
}
