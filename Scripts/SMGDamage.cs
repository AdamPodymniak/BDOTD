using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGDamage : MonoBehaviour
{
    #region Singleton
    public static SMGDamage instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("You stupic human did something wrong! Pathetic...");
        }
        instance = this;
    }
    #endregion

    public float damage = 3f;
    public int fireDamage = 0;
    public int shockDamage = 0;
}
