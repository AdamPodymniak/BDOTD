using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerHealth playerHealth;
    public PlayerHealthManager maxHealth;
    public HealthPotionNum potionNum;
    public ShotgunDamage shotgunDamage;
    public RevolverDamage revolverDamage;
    public SMGDamage smgDamage;
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        EquipManager.instance.onModChanged += OnModChanged;
    }
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
    }

    void OnModChanged(Modyfikators newMod, Modyfikators oldMod)
    {
        if(newMod != null && newMod.dmgModyfier != 0)
        {
            revolverDamage.damage += newMod.dmgModyfier;
            shotgunDamage.damage += newMod.dmgModyfier / 5;
            smgDamage.damage += newMod.dmgModyfier / 10;
        }
        if (oldMod != null && oldMod.dmgModyfier != 0)
        {
            revolverDamage.damage -= newMod.dmgModyfier;
            shotgunDamage.damage -= newMod.dmgModyfier / 5;
            smgDamage.damage -= newMod.dmgModyfier / 10;
        }
        if (newMod != null && newMod.healthModifier != 0)
        {
            maxHealth.maxHealth += newMod.healthModifier;
            playerHealth.healthBar.SetMaxHealth(maxHealth.maxHealth);
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
        }
        if (oldMod != null && oldMod.healthModifier != 0)
        {
            maxHealth.maxHealth -= oldMod.healthModifier;
            playerHealth.healthBar.SetMaxHealth(maxHealth.maxHealth);
            playerHealth.healthBar.SetHealth(playerHealth.currentHealth);
        }
        if (newMod != null && newMod.fireModyfier != 0)
        {
            revolverDamage.fireDamage += newMod.fireModyfier;
            shotgunDamage.fireDamage += newMod.fireModyfier;
            smgDamage.fireDamage += newMod.fireModyfier;
        }
        if (oldMod != null && oldMod.fireModyfier != 0)
        {
            revolverDamage.fireDamage -= oldMod.fireModyfier;
            shotgunDamage.fireDamage -= oldMod.fireModyfier;
            smgDamage.fireDamage -= oldMod.fireModyfier;
        }
        if (newMod != null && newMod.shockModyfier != 0)
        {
            revolverDamage.shockDamage += newMod.shockModyfier;
            shotgunDamage.shockDamage += newMod.shockModyfier;
            smgDamage.shockDamage += newMod.shockModyfier;
        }
        if (oldMod != null && oldMod.shockModyfier != 0)
        {
            revolverDamage.shockDamage -= oldMod.shockModyfier;
            shotgunDamage.shockDamage -= oldMod.shockModyfier;
            smgDamage.shockDamage -= oldMod.shockModyfier;
        }
        if (newMod != null && newMod.potionNumberModyfier != 0)
        {
            potionNum.maxNumOfPotions += newMod.potionNumberModyfier;
        }
        if (oldMod != null && oldMod.potionNumberModyfier != 0)
        {
            potionNum.maxNumOfPotions += newMod.potionNumberModyfier;
        }
        if (newMod != null && newMod.potionHealModyfier != 0)
        {
            potionNum.maxNumOfPotions += newMod.potionNumberModyfier;
        }
        if (oldMod != null && oldMod.potionHealModyfier != 0)
        {
            potionNum.amountOfHeal += newMod.potionHealModyfier;
        }
    }
}
