using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        //Find where coins are stored
    }

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        //Add coins to stored location
        gameObject.GetComponent<AudioSource>().Play();
    }
}
