using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public GameObject[] earlyGameItems;
    public GameObject[] midGameItems;
    public GameObject[] lateGameItems;

    private List<GameObject> spawnedItems = new List<GameObject>();

    public void SpawnItem(Vector3Int position, int gameStage)
    {
        GameObject[] items;

        if (gameStage >= 1 && gameStage <= 5) // i'll be grabbing that round int that we're currently in to decide which set of items to spawn in for power balancing
        {
            items = earlyGameItems;
        }
        else if (gameStage >= 6 && gameStage <= 10)
        {
            items = midGameItems;
        }
        else if (gameStage >= 11 && gameStage <= 13)
        {
            items = lateGameItems;
        }
        else
        {
            items = null;
        }

        if (items != null && items.Length > 0)
        {
            int randomNum = Random.Range(0, items.Length);
            GameObject itemPrefab = items[randomNum];
            GameObject spawnedItem = Instantiate(itemPrefab, position, Quaternion.identity); // yeah I needed help on this one cause quaternion tripped me up
            spawnedItems.Add(spawnedItem);
        }
    }

    public void ClearSpawnedItems()
    {
        // destroys all the items that were spawned in for that round
        foreach (GameObject item in spawnedItems)
        {
            Destroy(item);
        }

        spawnedItems.Clear();
    }
}
