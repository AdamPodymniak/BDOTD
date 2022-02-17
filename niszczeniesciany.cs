using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class niszczeniesciany : MonoBehaviour
{

    bool trigger;
    int index;

    private void Start()
    {
        trigger = false;
        index = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;

        }


    }

    public void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Destroy(gameObject);



            }
            




        }




    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        


    }
    





   


}
