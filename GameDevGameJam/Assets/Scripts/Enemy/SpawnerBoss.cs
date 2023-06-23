using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private float spawnTime;

    public List<GameObject> spawnPoints;
    public List<GameObject> enemies;
    public List<AudioClip> bossAudio;

    private AudioSource audioSource;

    private int count = 0;

    bool coroutineIsRunning = false;
    float t = 0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(BossSounds());
    }

    private void Update()
    {
        if(!coroutineIsRunning)
        {
            StartCoroutine(HandleSpawnEnemies());
        }

        if(player == null)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator HandleSpawnEnemies() {
        coroutineIsRunning = true;
        while (t < spawnTime)
        {
            t += Time.deltaTime;
            yield return null;
        }
        SpawnEnemy();
        t = 0f;
        coroutineIsRunning = false;

        yield return null;
    }

    public void SpawnEnemy()
    {
        int whichEnemy = Random.Range(0, enemies.Count);

        Vector3 spawnPosition = spawnPoints[count % spawnPoints.Count].transform.position;

        Instantiate(enemies[whichEnemy], spawnPosition, Quaternion.identity);
        count++;  
    }

    IEnumerator BossSounds()
    {
        audioSource.Play();
        yield return new WaitForSeconds(Random.Range(40, 50));
        audioSource.clip = bossAudio[Random.Range(0, bossAudio.Count)];
        StartCoroutine(BossSounds());
    }
}
