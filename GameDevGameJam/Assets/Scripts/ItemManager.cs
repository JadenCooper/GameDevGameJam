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
    public GameObject modsParent;
    public GameObject spriteParent;

    private List<GameObject> modTextList = new List<GameObject>();
    public int coins = 0;

    public void AddItem(Item newItem)
    {
        items.Add(newItem);
        playerStats.ItemChanged(newItem);
        StartCoroutine(PlayItemPopup(newItem));
    }

    private IEnumerator PlayItemPopup(Item item)
    {
        popUpParent.SetActive(true);
        Sprite sprite = item.icon;
        TMP_Text text = GameObject.Find("ItemText").GetComponent<TMP_Text>();
        for (int i = 0; i < item.mods.Length; i++)
        {
            if (item.mods[i] != 0)
            {
                GameObject modText = Instantiate(modsText, new Vector3(modsParent.transform.position.x, modsParent.transform.position.y, 0), Quaternion.identity);
                modText.transform.parent = modsParent.transform;
                modTextList.Add(modText);
                if (item.mods[i] < 0)
                {
                    modText.GetComponent<TMP_Text>().text = item.modsNames[i] + ": " + item.mods[i].ToString();
                }
                else
                {
                    modText.GetComponent<TMP_Text>().text = item.modsNames[i] + ": +" + item.mods[i].ToString();
                }

            }
        }
        spriteParent.GetComponent<Image>().sprite = sprite;

        text.text = "New Item! '" + item.name + "'";
        yield return new WaitForSeconds(3f);
        popUpParent.SetActive(false);
        modTextList.Clear();
    }

    public void AddCoins(int value)
    {
        coins += value;
        
        TMP_Text moneyText = GameObject.Find("MoneyCount").GetComponent<TMP_Text>();
        string moneyCounterText = "Coins: " + coins;
        moneyText.text = moneyCounterText;
    }
}
