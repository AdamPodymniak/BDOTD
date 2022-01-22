using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButtons : MonoBehaviour
{



    public GameObject Opcja1;
    public GameObject Opcja2;
    public GameObject Opcja3;
    public GameObject Opcja4;
    public GameObject Opcja5;
    private void Start()
    {
        

        Opcja1.SetActive(false);
        Opcja2.SetActive(false);
        Opcja3.SetActive(false);


    }



    public void Button1()
    {

        Opcja1.SetActive(true);


    }

    public void Button2()
    {

        Opcja2.SetActive(true);


    }
    public void Button3()
    {

        Opcja3.SetActive(true);


    }
    public void close()
    {

        
        Opcja4.SetActive(false);


    }
    public void cofnij()
    {

        Opcja1.SetActive(false);
        Opcja2.SetActive(false);
        Opcja3.SetActive(false);
        Opcja5.SetActive(true);

    }

}


    

