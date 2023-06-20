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

    public List<string> modsNames = new List<string>();
    public List<float> mods = new List<float>();

    private void Awake()
    {
        mods.Add(damageModifier);
        modsNames.Add("DMG");
        mods.Add(speedModifier);
        modsNames.Add("SPD");
        mods.Add(defenceModifier);
        modsNames.Add("DEF");
        mods.Add(healthModifier);
        modsNames.Add("HP");
        mods.Add(weightModifier);
        modsNames.Add("Weight");
        mods.Add(magSizeModifier);
        modsNames.Add("Mag Size");
        mods.Add(spreadModifier);
        modsNames.Add("Spread");
        mods.Add(bulletSpeedModifier);
        modsNames.Add("Bullet Speed");
        mods.Add(fireRateModifier);
        modsNames.Add("Fire Rate");
        mods.Add(reloadSpeedModifier);
        modsNames.Add("Reload");
        mods.Add(bulletWeightModifier);
        modsNames.Add("Bullet Weight");
        mods.Add(rangeModifier);
        modsNames.Add("Range");
    }
    public void PickUp()
    {
        ItemManager.instance.AddItem(this);
    }
}
