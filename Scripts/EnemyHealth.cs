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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RevolverBullet")
        {
            enemyHealth -= RevolverDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "ShotgunBullet")
        {
            enemyHealth -= ShotgunDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SMGBullet")
        {
            enemyHealth -= SMGDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}
