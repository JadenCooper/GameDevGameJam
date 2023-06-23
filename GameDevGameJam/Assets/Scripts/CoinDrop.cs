using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    [SerializeField]
    float chanceToSpawn = 50f; // Out of 100

    public GameObject coinPrefab;

    public void DropMoney()
    {
        float rand = Random.Range(1f, 100f);
        if(rand <= chanceToSpawn)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }
}
