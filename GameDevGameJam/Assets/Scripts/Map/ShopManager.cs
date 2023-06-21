using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShopManager : MonoBehaviour
{
    public Tilemap tilemap;
    private Dictionary<Vector3Int, TileBase> originalTiles;
    public ShopItems itemManager;
    public int gameStage;

    // https://www.youtube.com/watch?v=1Sah23KPEfU&ab_channel=Velvary
    void Start()
    {
        originalTiles = new Dictionary<Vector3Int, TileBase>(); 
        StoreOriginalTiles();
    }

    public void OpenGate()
    {
        Vector3Int[] tilePositions = 
        {
            new Vector3Int(10, 4, 0),  
            new Vector3Int(11, 4, 0), 
            new Vector3Int(12, 4, 0), 
            new Vector3Int(13, 4, 0), 
            new Vector3Int(14, 4, 0), 
            new Vector3Int(15, 4, 0), 
            new Vector3Int(16, 4, 0), 
            new Vector3Int(17, 4, 0), 
            new Vector3Int(18, 4, 0), 
            new Vector3Int(19, 4, 0), 
            new Vector3Int(10, 3, 0),  
            new Vector3Int(11, 3, 0), 
            new Vector3Int(12, 3, 0), 
            new Vector3Int(13, 3, 0), 
            new Vector3Int(14, 3, 0), 
            new Vector3Int(15, 3, 0), 
            new Vector3Int(16, 3, 0), 
            new Vector3Int(17, 3, 0), 
            new Vector3Int(18, 3, 0), 
            new Vector3Int(19, 3, 0), 
            new Vector3Int(10, 2, 0),  
            new Vector3Int(11, 2, 0), 
            new Vector3Int(12, 2, 0), 
            new Vector3Int(13, 2, 0), 
            new Vector3Int(14, 2, 0), 
            new Vector3Int(15, 2, 0), 
            new Vector3Int(16, 2, 0), 
            new Vector3Int(17, 2, 0), 
            new Vector3Int(18, 2, 0), 
            new Vector3Int(19, 2, 0), 
            new Vector3Int(10, 1, 0),  
            new Vector3Int(11, 1, 0), 
            new Vector3Int(12, 1, 0), 
            new Vector3Int(13, 1, 0), 
            new Vector3Int(14, 1, 0), 
            new Vector3Int(15, 1, 0), 
            new Vector3Int(16, 1, 0), 
            new Vector3Int(17, 1, 0), 
            new Vector3Int(18, 1, 0), 
            new Vector3Int(19, 1, 0),  
            new Vector3Int(10, 0, 0),  
            new Vector3Int(11, 0, 0), 
            new Vector3Int(12, 0, 0), 
            new Vector3Int(13, 0, 0), 
            new Vector3Int(14, 0, 0), 
            new Vector3Int(15, 0, 0), 
            new Vector3Int(16, 0, 0), 
            new Vector3Int(17, 0, 0), 
            new Vector3Int(18, 0, 0), 
            new Vector3Int(19, 0, 0),  
        };

        foreach (Vector3Int tilePosition in tilePositions)
        {
            tilemap.SetTile(tilePosition, null); 
        }

    
        Vector3Int[] itemPositions = 
        {
            new Vector3Int(10, 8, 0),  
            new Vector3Int(11, 7, 0), 
            new Vector3Int(19, 7, 0), 
            new Vector3Int(15, 6, 0), 
        };

        SpawnItems(itemPositions); // will spawn in clones of the item gameobjects or prefabs we give
    }

    public void CloseGate()
    {
        foreach (var tiles in originalTiles)
        {
            Vector3Int position = tiles.Key;
            TileBase tile = tiles.Value;
            tilemap.SetTile(position, tile);
        }
        itemManager.ClearSpawnedItems();
    }

    private void StoreOriginalTiles()
    {
        // https://gamedev.stackexchange.com/questions/150917/how-to-get-all-tiles-from-a-tilemap 
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            TileBase tile = tilemap.GetTile(position);
            originalTiles[position] = tile;
        }
    }


    public void SpawnItems(Vector3Int[] itemPositions)
    {
        foreach (Vector3Int position in itemPositions)
        {
            TileBase tile = tilemap.GetTile(position);
            if (tile != null)
            {
                Vector3Int spawnPosition = Vector3Int.RoundToInt(tilemap.GetCellCenterWorld(position)); // it gets the position that i've given it in the array and will spawn the item thats on the corresponding stage we're in
                tilemap.SetTile(position, null);
                itemManager.SpawnItem(spawnPosition, gameStage);
            }
        }
    }
}
