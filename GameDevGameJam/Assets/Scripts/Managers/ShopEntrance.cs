using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public bool inShop = false;

    public ShopManager shop;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inShop = !inShop;

            if (!ArenaManager.instance.hasShopped && !inShop)
            {
                ArenaManager.instance.hasShopped = true;
                StartCoroutine(CloseDoor());
            }
        }
    }

    private void Update()
    {
        if (ArenaManager.instance.end && !shop.isOpen)
        {
            StartCoroutine(OpenDoor());
        }
    }

    private IEnumerator CloseDoor()
    {
        AudioManager.instance.DoorClose();
        yield return new WaitForSeconds(5f);
        shop.CloseGate();
        
    }

    private IEnumerator OpenDoor()
    {
        shop.OpenGate();
        AudioManager.instance.DoorOpen();
        yield return new WaitForSeconds(3f);        
    }
}
