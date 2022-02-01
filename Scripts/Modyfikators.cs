using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Modyficator", menuName = "Inventory/Modyficators")]
public class Modyfikators : Item
{
    public Sprite modIcon = null;
    public string description = null;
    public float dmgModyfier = 0;
    public int healthModifier = 0;
    public int fireModyfier = 0;
    public int shockModyfier = 0;

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
    public override void Use()
    {
        base.Use();
        EquipManager.instance.Equip(this);
        RemoveFromInventory();
    }
}
