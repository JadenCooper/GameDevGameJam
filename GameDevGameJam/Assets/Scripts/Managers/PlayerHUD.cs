using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    public CharacterStats characterStats;
    public RangedWeapon rangedWeapon;

    public TextMeshProUGUI currentHealthText;
    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI speed;
    public TextMeshProUGUI defence;
    public TextMeshProUGUI firerate;

    public GameObject playerStats;

    private bool isShowing;

    private void Awake()
    {
        isShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleTextDisplay();
    }

    public void HandleTextDisplay()
    {
        DisplayHealth();
        DisplayAmmoCount();
        DisplayPlayerStats();
    }

    public void DisplayHealth()
    {
        currentHealthText.text = characterStats.currentHealth.ToString() + " / " + characterStats.maxHealth.ToString();
    }

    public void DisplayAmmoCount()
    {
        ammoCount.text = "Ammo: " + rangedWeapon.currentClip.ToString() + " / " + characterStats.magSize.GetValue().ToString();
    }

    public void AlterStatsDisplay()
    {
        isShowing = !isShowing;
    }
    public void DisplayPlayerStats()
    {
        if (!isShowing)
        {
            playerStats.SetActive(false);
        }
        else
        {
            playerStats.SetActive(true);
            damage.text = "Damage: " + characterStats.damage.GetValue().ToString();
            speed.text = "Speed: " + characterStats.speed.GetValue().ToString();
            defence.text = "Defence: " + characterStats.defence.GetValue().ToString();
            firerate.text = "Shoot Delay: " + characterStats.fireRate.GetValue().ToString();
        }
    }

    public void HidePlayerStats()
    {
        playerStats.SetActive(false);
    }
}
