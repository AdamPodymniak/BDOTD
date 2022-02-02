using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemList : MonoBehaviour
{
    public enum ItemType
    {
        HealthPotion,
        ModSlot,
        UpgradeItem,
        SizePillP,
        SizePillM,
    }
    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return 50;
            case ItemType.ModSlot: return 100;
            case ItemType.UpgradeItem: return 100;
            case ItemType.SizePillP: return 20;
            case ItemType.SizePillM: return 20;
        }
    }
    public static string GetName(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.HealthPotion: return "Health Potion: ";
            case ItemType.ModSlot: return "Mod Slot: ";
            case ItemType.UpgradeItem: return "Upgrade Item: ";
            case ItemType.SizePillP: return "Size Pill +: ";
            case ItemType.SizePillM: return "Size pill -: ";
        }
    }
}
