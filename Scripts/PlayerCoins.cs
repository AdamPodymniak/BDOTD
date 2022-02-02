using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    #region Singleton
    public static PlayerCoins instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public int numOfCoins;
}
