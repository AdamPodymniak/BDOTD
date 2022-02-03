using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public OnItemChange onItemChangeCallback;
    #region Singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChange();
    public int inventorySpace = 20;
    public List<Modyfikators> items = new List<Modyfikators>();
    public bool Add(Modyfikators item)
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
    public void Remove(Modyfikators item)
    {
        items.Remove(item);

        if (onItemChangeCallback != null)
        {
            onItemChangeCallback.Invoke();
        }
    }
}
