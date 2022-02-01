using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverDamage : MonoBehaviour
{
    #region Singleton
    public static RevolverDamage instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public float damage = 70f;
    public int fireDamage = 0;
    public int shockDamage = 0;
}
