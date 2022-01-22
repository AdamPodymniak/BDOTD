using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npcdialogue : MonoBehaviour
{
    
    public GameObject NpcD;
    public GameObject pressE;
    public GameObject dialog;
    public bool es = false;
    
    // Start is called before the first frame update
    void Start()
    {
        NpcD.SetActive(false);
        pressE.SetActive(false);
        dialog.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            pressE.SetActive(true);
            es = true;
            


            


        }


    }

    // Update is called once per frame
    void Update()
    {


        if (es == true)
        {



            if (Input.GetKeyDown(KeyCode.E))
            {

                NpcD.SetActive(!NpcD.activeSelf);

            }
        }
    }
}
