using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Healtbar healthBar;
    public int damage;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            if(currentHealth <= 0)
            {
                Destroy(gameObject);
                SceneLoader.sceneLoaderButton.Show();
            }
            currentHealth -= collision.gameObject.GetComponent<BulletFollow>().damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
