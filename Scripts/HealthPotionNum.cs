using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotionNum : MonoBehaviour
{
    #region Singleton
    public static HealthPotionNum instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public int numOfPotions;
    public int maxNumOfPotions;
    public int amountOfHeal;
}
