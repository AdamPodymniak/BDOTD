using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;
    public int inventorySpace = 20;
    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= inventorySpace)
        {
            return false;
        }
        items.Add(item);

        if(onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
}