using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEntrance : MonoBehaviour
{
    public bool inShop = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inShop = !inShop;

            if (!ArenaManager.instance.hasShopped && !inShop)
            {
                ArenaManager.instance.hasShopped = true;
            }

            if (inShop)
            {
                //Door.Close()
            }
        }
    }
}
