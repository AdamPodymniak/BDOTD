using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public HoverTip hoverTip;
    Modyfikators mod;

    public void AddItem(Modyfikators newItem)
    {
        mod = newItem;
        hoverTip.tipToShow = mod.description;
        icon.sprite = mod.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }
    public void ClearSlot()
    {
        mod = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(mod);
    }
    public void ActivateGem()
    {
        if(mod != null)
        {
            mod.Use();
        }
    }
}
