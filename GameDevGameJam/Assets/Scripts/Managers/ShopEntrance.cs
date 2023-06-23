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
        if (!shop.isOpen && ArenaManager.instance.end)
        {  
            switch (ArenaManager.instance.currentWave)
            {
                case 2:
                    StartCoroutine(OpenDoor());
                break;
                case 4:
                    StartCoroutine(OpenDoor());
                break;
                case 6:
                    StartCoroutine(OpenDoor());
                break;
                case 8:
                    StartCoroutine(OpenDoor());
                break;
                default:
                ArenaManager.instance.hasShopped = true;
                break;
            }
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
