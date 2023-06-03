using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class PlayerStats : CharacterStats
{
    public GameObject deathscreen;
    public GameObject grid;
    public void ItemChanged(Item newItem)
    {
        //if (newItem != null)
        //{
        //    damage.AddModifier(newItem.damageModifier);
        //    speed.AddModifier(newItem.speedModifier);
        //    defence.AddModifier(newItem.defenceModifier);
        //    if (newItem.healthModifier > 0)
        //    {
        //        maxHealth += newItem.healthModifier;
        //        currentHealth += newItem.healthModifier;
        //        ChangeHealth?.Invoke(currentHealth);
        //    }
        //    weight.AddModifier(newItem.weightModifier);
        //    magSize.AddModifier(newItem.magSizeModifier);
        //    spread.AddModifier(newItem.spreadModifier);
        //    bulletSpeed.AddModifier(newItem.bulletSpeedModifier);
        //    fireRate.AddModifier(newItem.fireRateModifier);
        //    reloadSpeed.AddModifier(newItem.reloadSpeedModifier);
        //    bulletWeight.AddModifier(newItem.bulletWeightModifier);
        //    range.AddModifier(newItem.rangeModifier);
        //}

        //if (newItem != null)
        //{
        //    damage.RemoveModifier(oldItem.damageModifier);
        //    speed.RemoveModifier(oldItem.speedModifier);
        //}
    }

    public override void Die()
    {
        //Add player Death Stuff

        base.Die();
    }
}
