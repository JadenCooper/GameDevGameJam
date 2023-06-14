using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public List<GameObject> enemies;
    public float spawnInterval = 2;
    public List<int> maxEnemies;
}

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointParent;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public Wave[] waves;
    public float waveInterval = 5f;
    private float lastSpwanTime;
    private int enemiesSpawned = 0;
    private int totalEnemies;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform t in spawnPointParent.GetComponentsInChildren<Transform>())
        {
            if (t.gameObject.name != spawnPointParent.name)
            {
                spawnPoints.Add(t);
            }
        }

        lastSpwanTime = Time.time;
        totalEnemies = waves[0].maxEnemies.Sum();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
