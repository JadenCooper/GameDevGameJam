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
    #region Singleton
    public static ArenaManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ArenaManager>();
            }
            return _instance;
        }
    }
    static ArenaManager _instance;

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    [SerializeField] private GameObject spawnPointParent;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();

    [HideInInspector] public List<GameObject> enemies = new List<GameObject>();

    public Wave[] waves;
    public float waveInterval = 5f;

    private int currentWave = 0;
    private float lastSpwanTime;
    private int enemiesSpawned = 0;
    public bool end = false;
    [HideInInspector] public bool hasShopped = true;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWave < waves.Count())
        {
            float timeInterval = Time.time - lastSpwanTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (timeInterval > spawnInterval)
            {
                GameObject newEnemy = null;
                lastSpwanTime = Time.time;
                if (enemiesSpawned <= waves[currentWave].maxEnemies)
                {
                    newEnemy = Instantiate((waves[currentWave].enemies[UnityEngine.Random.Range(0, waves[currentWave].enemies.Count())]));
                    newEnemy.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count())].transform.position;
                    enemies.Add(newEnemy);
                    enemiesSpawned++;
                    if (enemiesSpawned == waves[currentWave].maxEnemies)
                    {
                        end = true;
                        hasShopped = false;
                    }
                }
                else if (end && hasShopped)
                {
                    StartCoroutine(StartNewWave());
                }
            }
        }
    }

    public IEnumerator StartNewWave()
    {
        end = false;
        yield return new WaitForSeconds(waveInterval);
        currentWave++;
        enemiesSpawned = 0;
    }
}
