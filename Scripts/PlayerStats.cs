using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerHealth playerHealth;
    void Start()
    {
        EquipManager.instance.onModChanged += OnModChanged;
    }

    void OnModChanged(Modyfikators newMod, Modyfikators oldMod)
    {
        if(newMod != null && newMod.dmgModyfier != 0)
        {
            RevolverDamage.instance.damage += newMod.dmgModyfier;
            ShotgunDamage.instance.damage += newMod.dmgModyfier / 5;
            SMGDamage.instance.damage += newMod.dmgModyfier / 10;
        }
        if (oldMod != null && oldMod.dmgModyfier != 0)
        {
            RevolverDamage.instance.damage -= oldMod.dmgModyfier;
            ShotgunDamage.instance.damage -= oldMod.dmgModyfier / 5;
            SMGDamage.instance.damage -= oldMod.dmgModyfier / 10;
        }
        if (newMod != null && newMod.healthModifier != 0)
        {
            playerHealth.maxHealth += newMod.healthModifier;
            playerHealth.healthBar.SetMaxHealth(playerHealth.maxHealth);
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
        }
        if (oldMod != null && oldMod.healthModifier != 0)
        {
            playerHealth.maxHealth -= newMod.healthModifier;
            playerHealth.healthBar.SetMaxHealth(playerHealth.maxHealth);
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
        }
        if (newMod != null && newMod.fireModyfier != 0)
        {
            RevolverDamage.instance.fireDamage += newMod.fireModyfier;
            ShotgunDamage.instance.fireDamage += newMod.fireModyfier;
            SMGDamage.instance.fireDamage += newMod.fireModyfier;
        }
        if (oldMod != null && oldMod.fireModyfier != 0)
        {
            RevolverDamage.instance.fireDamage -= oldMod.fireModyfier;
            ShotgunDamage.instance.fireDamage -= oldMod.fireModyfier;
            SMGDamage.instance.fireDamage -= oldMod.fireModyfier;
        }
        if (newMod != null && newMod.shockModyfier != 0)
        {
            RevolverDamage.instance.shockDamage += newMod.shockModyfier;
            ShotgunDamage.instance.shockDamage += newMod.shockModyfier;
            SMGDamage.instance.shockDamage += newMod.shockModyfier;
        }
        if (oldMod != null && oldMod.shockModyfier != 0)
        {
            RevolverDamage.instance.shockDamage -= oldMod.shockModyfier;
            ShotgunDamage.instance.shockDamage -= oldMod.shockModyfier;
            SMGDamage.instance.shockDamage -= oldMod.shockModyfier;
        }
    }
}
