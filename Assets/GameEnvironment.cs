using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sealed - this class can't be used to create other classes
// No other classes can inherit from this class
public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> goalLocations = new List<GameObject>();

    public List<GameObject> Obstacles { get { return obstacles; } }
    public List<GameObject> GoalLocations { get { return goalLocations; } }

    public static GameEnvironment Singleton
    {
        get
        {
            if (instance == null)
            {
                instance = new GameEnvironment();
                // This is the instantiation of this class, therefore adding goals should be added through the object itself and not the class variables
                // !! THIS is the object that exists as a singleton in memory !!
                // This part here is essentially an equivalent of a constructor for the singelton
                // This part is where you would put all your initializations that need to be done, but do them to 'instance'
                // instance.score = 50;...
                // instance.enemies.AddRange(list);...
                instance.goalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            }

            return instance;
        }
    }

    // Methods below are running on the actual instance themselves, therefore there is no need to put 'instance' in that case.
    public GameObject GetRandomGoal()
    {
        int index = Random.Range(0, goalLocations.Count);
        return goalLocations[index];
    }

    public void AddObstacles(GameObject go)
    {
        obstacles.Add(go);
    }

    public void RemoveObstacles(GameObject go)
    {
        int index = obstacles.IndexOf(go);
        obstacles.RemoveAt(index);
        GameObject.Destroy(go);
    }
}
