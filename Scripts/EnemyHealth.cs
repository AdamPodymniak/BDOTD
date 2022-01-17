using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float enemyHealth;
    public ChangeEnemyHealthUI healthbar;

    private void Start()
    {
        healthbar.SetMaxHealth(enemyHealth);
    }

    private void Update()
    {
        healthbar.SetHealth(enemyHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            enemyHealth -= 10f;
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
