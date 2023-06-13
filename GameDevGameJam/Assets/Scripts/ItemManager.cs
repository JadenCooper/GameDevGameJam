using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    #region Singleton
    public static ItemManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ItemManager>();
            }
            return _instance;
        }
    }
    static ItemManager _instance;

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public PlayerStats playerStats;
    public GameObject popUpParent;
    public GameObject modsText;
    public int coins = 0;

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        playerStats.ItemChanged(newItem);
        //StartCoroutine(PlayItemPopup(newItem));
    }

    private IEnumerator PlayItemPopup(Item item)
    {
        popUpParent.SetActive(true);
        //Sprite sprite = popUpParent.GetComponentInChildren<Image>().sprite;
        TMP_Text text = GameObject.Find("ItemText").GetComponent<TMP_Text>();
        //for (int i = 0; i < item.mods.Count; i++)
        //{
        //    if (item.mods[i] != 0)
        //    {
        //        GameObject ModsParent = GameObject.Find("ListOfMods");
        //        GameObject ModText = Instantiate(modsText, new Vector3(ModsParent.transform.position.x, ModsParent.transform.position.y, 0), Quaternion.identity);
        //        ModText.transform.parent = ModsParent.transform;
        //        if (item.mods[i] < 0)
        //        {
        //            ModText.GetComponent<TMP_Text>().text = item.modsNames[i] + ": -" + item.mods[i].ToString();
        //        }
        //        else
        //        {
        //            ModText.GetComponent<TMP_Text>().text = item.modsNames[i] + ": +" + item.mods[i].ToString();
        //        }

        //    }

        //}
        //Debug.Log(sprite);
        //sprite = item.icon;
        //Debug.Log(sprite);

        text.text = "New Item! '" + item.name + "'";
        yield return new WaitForSeconds(3f);
        popUpParent.SetActive(false);
    }

    public void AddCoins(int value)
    {
        coins += value;
    }
}
