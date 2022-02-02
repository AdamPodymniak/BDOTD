using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    #region Singleton
    public static PlayerHealthManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion
    public int maxHealth;
}
