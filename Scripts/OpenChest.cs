using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour
{
    Modyfikators createNewMod;
    public int numOfItems;
    public Sprite greyIcon;
    public Sprite blueIcon;
    public Sprite greenIcon;
    public Sprite purpleIcon;
    public Sprite goldIcon;
    public GameObject modPickUp;
    int rarityLevel;
    public int rarityChestLevel;
    int chooseModType;
    float randomDmg;
    int randomHealth;
    int randomFire;
    int randomShock;
    int randomPotionNum;
    int randomHeal;
    bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isOpen)
        {
             for (int i = 0; i < numOfItems+1; i++)
            {
                Instantiate(modPickUp, transform.position, Quaternion.identity);
                createNewMod = ScriptableObject.CreateInstance<Modyfikators>();
                if (rarityChestLevel == 1)
                {
                    rarityLevel = Random.Range(0, 10);
                    if (rarityLevel == 0)
                    {
                        createNewMod.icon = blueIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.blue;
                        randomDmg = 2 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(6, 10);
                        randomFire = 1 * Random.Range(6, 10);
                        randomShock = 1 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(4, 6);
                        randomPotionNum = 1 * Random.Range(4, 6);
                    }
                    else if (rarityLevel == 1 || rarityLevel == 2)
                    {
                        createNewMod.icon = greenIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.green;
                        randomDmg = 2 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(3, 6);
                        randomFire = 1 * Random.Range(3, 6);
                        randomShock = 1 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(2, 4);
                        randomPotionNum = 1 * Random.Range(2, 4);
                    }
                    else
                    {
                        createNewMod.icon = greyIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.grey;
                        randomDmg = 2 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 3);
                        randomFire = 1 * Random.Range(1, 3);
                        randomShock = 1 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 2);
                        randomPotionNum = 1 * Random.Range(1, 2);
                    }
                }
                else if (rarityChestLevel == 2)
                {
                    rarityLevel = Random.Range(0, 10);
                    if (rarityLevel == 0)
                    {
                        createNewMod.icon = purpleIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.magenta;
                        randomDmg = 2 * Random.Range(10, 15);
                        randomHealth = 10 * Random.Range(10, 15);
                        randomFire = 1 * Random.Range(10, 15);
                        randomShock = 1 * Random.Range(10, 15);
                        randomHealth = 10 * Random.Range(6, 10);
                        randomPotionNum = 1 * Random.Range(6, 10);
                    }
                    else if (rarityLevel == 1 || rarityLevel == 2)
                    {
                        createNewMod.icon = blueIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.blue;
                        randomDmg = 2 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(6, 10);
                        randomFire = 1 * Random.Range(6, 10);
                        randomShock = 1 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(4, 6);
                        randomPotionNum = 1 * Random.Range(4, 6);
                    }
                    else if (rarityLevel == 3 || rarityLevel == 4 || rarityLevel == 5)
                    {
                        createNewMod.icon = greenIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.green;
                        randomDmg = 2 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(3, 6);
                        randomFire = 1 * Random.Range(3, 6);
                        randomShock = 1 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(2, 4);
                        randomPotionNum = 1 * Random.Range(2, 4);
                    }
                    else
                    {
                        createNewMod.icon = greyIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.grey;
                        randomDmg = 2 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 3);
                        randomFire = 1 * Random.Range(1, 3);
                        randomShock = 1 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 2);
                        randomPotionNum = 1 * Random.Range(1, 2);
                    }

                }
                else if (rarityChestLevel == 3)
                {
                    rarityLevel = Random.Range(0, 10);
                    if (rarityLevel == 0)
                    {
                        createNewMod.icon = goldIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.yellow;
                        randomDmg = 2 * Random.Range(15, 30);
                        randomHealth = 10 * Random.Range(15, 30);
                        randomFire = 1 * Random.Range(15, 30);
                        randomShock = 1 * Random.Range(15, 30);
                        randomHealth = 10 * Random.Range(10, 20);
                        randomPotionNum = 1 * Random.Range(10, 20);
                    }
                    else if (rarityLevel == 1 || rarityLevel == 2)
                    {
                        createNewMod.icon = purpleIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.magenta;
                        randomDmg = 2 * Random.Range(10, 15);
                        randomHealth = 10 * Random.Range(10, 15);
                        randomFire = 1 * Random.Range(10, 15);
                        randomShock = 1 * Random.Range(10, 15);
                        randomHealth = 10 * Random.Range(6, 10);
                        randomPotionNum = 1 * Random.Range(6, 10);
                    }
                    else if (rarityLevel == 3 || rarityLevel == 4 || rarityLevel == 5)
                    {
                        createNewMod.icon = blueIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.blue;
                        randomDmg = 2 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(6, 10);
                        randomFire = 1 * Random.Range(6, 10);
                        randomShock = 1 * Random.Range(6, 10);
                        randomHealth = 10 * Random.Range(4, 6);
                        randomPotionNum = 1 * Random.Range(4, 6);
                    }
                    else if (rarityLevel == 6 || rarityLevel == 7 || rarityLevel == 8)
                    {
                        createNewMod.icon = greenIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.green;
                        randomDmg = 2 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(3, 6);
                        randomFire = 1 * Random.Range(3, 6);
                        randomShock = 1 * Random.Range(3, 6);
                        randomHealth = 10 * Random.Range(2, 4);
                        randomPotionNum = 1 * Random.Range(2, 4);
                    }
                    else
                    {
                        createNewMod.icon = greyIcon;
                        modPickUp.GetComponent<SpriteRenderer>().color = Color.grey;
                        randomDmg = 2 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 3);
                        randomFire = 1 * Random.Range(1, 3);
                        randomShock = 1 * Random.Range(1, 3);
                        randomHealth = 10 * Random.Range(1, 2);
                        randomPotionNum = 1 * Random.Range(1, 2);
                    }
                }
                    chooseModType = Random.Range(0, 6);
                if (chooseModType == 0)
                {
                    createNewMod.dmgModyfier = randomDmg;
                    createNewMod.description = "Damage: +" + randomDmg.ToString();
                }
                else if (chooseModType == 1)
                {
                    createNewMod.healthModifier = randomHealth;
                    createNewMod.description = "Health: +" + randomHealth.ToString();
                }
                else if (chooseModType == 2)
                {
                    createNewMod.fireModyfier = randomFire;
                    createNewMod.description = "Fire Damage: +" + randomFire.ToString();
                }
                else if (chooseModType == 3)
                {
                    createNewMod.shockModyfier = randomShock;
                    createNewMod.description = "Shock Damage: +" + randomShock.ToString();
                }
                else if (chooseModType == 4)
                {
                    createNewMod.potionNumberModyfier = randomShock;
                    createNewMod.description = "Bonus Potions: +" + randomShock.ToString();
                }
                else if (chooseModType == 5)
                {
                    createNewMod.potionHealModyfier = randomShock;
                    createNewMod.description = "Bonus Heal: +" + randomShock.ToString();
                }
                    modPickUp.GetComponent<ItemPickUp>().item = createNewMod;
                    modPickUp.SetActive(true);
                }
            isOpen = true;
        }
        modPickUp.SetActive(false);
    }
}
