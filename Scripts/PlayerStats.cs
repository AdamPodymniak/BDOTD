using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    void Start()
    {
        EquipManager.instance.onModChanged += OnModChanged;
    }

    void OnModChanged(Modyfikators newMod, Modyfikators oldMod)
    {
        if(newMod != null)
        {
            RevolverDamage.instance.damage += newMod.dmgModyfier;
            ShotgunDamage.instance.damage += newMod.dmgModyfier / 5;
            SMGDamage.instance.damage += newMod.dmgModyfier / 10;
        }
        if (oldMod != null)
        {
            RevolverDamage.instance.damage -= oldMod.dmgModyfier;
            ShotgunDamage.instance.damage -= oldMod.dmgModyfier / 5;
            SMGDamage.instance.damage -= oldMod.dmgModyfier / 10;
        }
    }
}
