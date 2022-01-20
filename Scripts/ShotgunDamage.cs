using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunDamage : MonoBehaviour
{
    #region Singleton
    public static ShotgunDamage instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public float damage = 5f;
}
