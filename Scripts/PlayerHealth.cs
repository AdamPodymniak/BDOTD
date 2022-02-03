using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public PlayerStats healtStat;
    private int maxHealth;
    public int currentHealth;
    public Healtbar healthBar;
    public int damage;

    private void Start()
    {
        maxHealth = PlayerHealthManager.instance.maxHealth;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(HealthPotionNum.instance.numOfPotions > 0)
            {
                currentHealth += HealthPotionNum.instance.amountOfHeal;
                healthBar.SetHealth(currentHealth);
                HealthPotionNum.instance.numOfPotions--;
            }
        }
    }
}
