using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;


[System.Serializable]
public class Wave
{
    public List<GameObject> enemies;
    public float spawnInterval = 2;
    public int maxEnemies;
}

public class ArenaManager : MonoBehaviour
{
    [SerializeField] private GameObject spawnPointParent;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    public Wave[] waves;
    public float waveInterval = 5f;

    private int currentWave = 0;
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
        totalEnemies = waves[currentWave].maxEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned < totalEnemies)
        {
            float timeInterval = Time.time - lastSpwanTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (timeInterval > spawnInterval)
            {
                GameObject newEnemy = null;
                lastSpwanTime = Time.time;
                if (enemiesSpawned <= waves[currentWave].maxEnemies)
                {
                    newEnemy = (GameObject)Instantiate((waves[currentWave].enemies[UnityEngine.Random.Range(0, waves[currentWave].enemies.Count())]), spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count())]);
                    enemiesSpawned++;
                }
                if (totalEnemies == waves[currentWave].maxEnemies)
                {
                    StartCoroutine(StartNewWave());
                }
            }
        }
    }

    public IEnumerator StartNewWave()
    {
        yield return new WaitForSeconds(waveInterval);
        currentWave++;
        enemiesSpawned = 0;
        totalEnemies = waves[currentWave].maxEnemies;
    }
}
