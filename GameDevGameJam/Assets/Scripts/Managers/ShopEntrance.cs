using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public bool inShop = false;
    public GameObject door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inShop = !inShop;

            if (!ArenaManager.instance.hasShopped && !inShop)
            {
                ArenaManager.instance.hasShopped = true;
                StartCoroutine(CloseDoorTest());
            }

            if (inShop)
            {

            }
        }
    }

    private void Update()
    {
        if (ArenaManager.instance.end && door.activeInHierarchy == true)
        {
            OpenDoor();
        }
    }

    public void CloseDoor()
    {
        door.SetActive(true);
    }

    private IEnumerator CloseDoorTest()
    {
        AudioManager.instance.DoorClose();
        yield return new WaitForSeconds(5f);
        CloseDoor();
    }

    public void OpenDoor()
    {
        AudioManager.instance.DoorOpen();
        door.SetActive(false);
    }
    private IEnumerator OpenDoorTest()
    {
        yield return new WaitForSeconds(5f);
        door.SetActive(false);
    }
}
