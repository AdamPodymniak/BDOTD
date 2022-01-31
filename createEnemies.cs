using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createEnemies : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource ambientMusic;
    public GameObject SpawnEnemies;
    public GameObject Wrota;
    public GameObject Wrota2;
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
            ambientMusic.Play();
            ambientMusic.loop = true;
            audioSource.Play();
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
            audioSource.Play();
            ambientMusic.Stop();
            Wrota.SetActive(false);
            Wrota2.SetActive(false);
            Skrzynia.SetActive(true);
            NpcD.SetActive(true);
        }


    }
}
