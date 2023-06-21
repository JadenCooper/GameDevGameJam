using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;

    public void Start()
    {
        if (item.icon != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        }

    }
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        
        item.PickUp();
        Debug.Log(item.name);
        AudioManager.instance.ItemPickup();
        Destroy(gameObject);
    }
}
