using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    Modyfikators createNewMod;
    public GameObject modPickUp;
    int chooseModType;
    bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !isOpen)
        {
                for (int i = 0; i < 5; i++)
                {
                    chooseModType = Random.Range(0, 4);
                    createNewMod = ScriptableObject.CreateInstance<Modyfikators>();
                    if (chooseModType == 0)
                    {
                        createNewMod.dmgModyfier = 10f;
                    createNewMod.description = "Damage: +" + 10.ToString();
                    }
                    else if (chooseModType == 1)
                    {
                        createNewMod.healthModifier = 100;
                    createNewMod.description = "Health: +" + 100.ToString();
                }
                    else if (chooseModType == 2)
                    {
                        createNewMod.fireModyfier = 5;
                    createNewMod.description = "Fire Damage: +" + 5.ToString();
                }
                    else
                    {
                        createNewMod.shockModyfier = 5;
                    createNewMod.description = "Shock Damage: +" + 5.ToString();
                }
                    Instantiate(modPickUp, transform.position, Quaternion.identity);
                    modPickUp.GetComponent<ItemPickUp>().item = createNewMod;
                    modPickUp.SetActive(true);
                }
            isOpen = true;
        }
        modPickUp.SetActive(false);
    }
}
