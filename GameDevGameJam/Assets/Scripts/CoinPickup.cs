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
    [SerializeField] private int max = 99;

    // Start is called before the first frame update
    void Start()
    {
        //We add 1 here so the inspector input is inclusive
        value = Random.Range(min, max + 1);
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        ItemManager.instance.AddCoins(value);
        gameObject.GetComponent<AudioSource>().Play();
    }
}
