using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsUI : MonoBehaviour
{
    public TextMeshProUGUI damage;
    public TextMeshProUGUI shockDamage;
    public TextMeshProUGUI fireDamage;
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI playerHeal;

    private void Update()
    {
        damage.text = ": +" + RevolverDamage.instance.damage;
        shockDamage.text = ": +" + RevolverDamage.instance.shockDamage;
        fireDamage.text = ": +" + RevolverDamage.instance.fireDamage;
        playerHealth.text = ": +" + PlayerHealthManager.instance.maxHealth;
        playerHeal.text = ": +" + HealthPotionNum.instance.amountOfHeal;
    }
}
