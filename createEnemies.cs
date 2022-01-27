using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemies : MonoBehaviour
{

    public GameObject SpawnEnemies;
    public GameObject Wrota;
    public GameObject Skrzynia;
    public GameObject NpcD;
    void Start()
    {

        SpawnEnemies.SetActive(false);


        Wrota.SetActive(false);
        Skrzynia.SetActive(false);
        NpcD.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnEnemies.SetActive(true);
            Wrota.SetActive(true);
            NpcD.SetActive(false);

            Debug.Log("essa");

        }


    }
    // Update is called once per frame
    void Update()
    {
        Skrzynia.SetActive(false);
        if (enemyCount.instance.enemiesCount <= 0)
        {

            Wrota.SetActive(false);
            Skrzynia.SetActive(true);
            NpcD.SetActive(true);
        }


    }
}
