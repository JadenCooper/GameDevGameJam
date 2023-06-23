using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinPickup : Interactable
{
    [SerializeField] private int value = 0;
    [SerializeField] private int min = 1;
    [SerializeField] private int max = 200;
    [SerializeField] private Sprite bigCoinPile;


    // Start is called before the first frame update
    void Start()
    {
        //We add 1 here so the inspector input is inclusive
        value = Random.Range(min, max + 1);

        if (value >= 100)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bigCoinPile;
        }

    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        ItemManager.instance.AddCoins(value);
        AudioManager.instance.CoinPickup();
        Destroy(gameObject);
    }
}
