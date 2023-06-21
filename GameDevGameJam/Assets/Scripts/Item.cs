using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;

    public float damageModifier;
    public float speedModifier;
    public float defenceModifier;
    public float healthModifier;
    public float weightModifier;

    public float magSizeModifier;
    public float spreadModifier;
    public float bulletSpeedModifier;
    public float fireRateModifier;
    public float reloadSpeedModifier;
    public float bulletWeightModifier;
    public float rangeModifier;

    public string[] modsNames = {
        "DMG",
        "SPD",
        "DEF",
        "HP",
        "Weight",
        "Mag Size",
        "Spread",
        "Bullet Speed",
        "Fire Rate",
        "Reload",
        "Bullet Weight",
        "Range"
        };
    public float[] mods = new float[12];

    private void Awake()
    {
         
    }
    public void PickUp()
    {
        mods[0] = damageModifier;
        mods[1] = speedModifier;
        mods[2] = defenceModifier;
        mods[3] = healthModifier;
        mods[4] = weightModifier;
        mods[5] = magSizeModifier;
        mods[6] = spreadModifier;
        mods[7] = bulletSpeedModifier;
        mods[8] = fireRateModifier;
        mods[9] = reloadSpeedModifier;
        mods[10] = bulletWeightModifier;
        mods[11] = rangeModifier;

        ItemManager.instance.AddItem(this);
    }
}
