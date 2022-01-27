using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modyficator", menuName = "Inventory/Modyficators")]
public class Modyfikators : Item
{
    public float dmgModyfier = 0;
    public int healthModifier = 0;

    public override void Use()
    {
        base.Use();
        EquipManager.instance.Equip(this);
        RemoveFromInventory();
    }
}
