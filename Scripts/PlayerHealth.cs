using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private bool immunity = false;
    public float immunityCount;
    private float immunityOryginal;

    private void Start()
    {
        immunityOryginal = immunityCount;
    }

    void Update()
    {

        if (immunity)
        {
            if(immunityCount <= 0)
            {
                immunity = false;
                immunityCount = immunityOryginal;
            }else
            {
                immunityCount -= Time.deltaTime;
            }
        }

        if(health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }else
            {
                hearts[i].enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            if(!immunity)
            {
                health -= 1;
                if (health <= 0)
                {
                    Destroy(gameObject, .05f);
                    SceneLoader.sceneLoaderButton.Show();
                }
                immunity = true;
            }
        }
        if (collision.gameObject.tag == "RespawnPoint")
        {
            health = numOfHearts;
        }
    }
        
}
