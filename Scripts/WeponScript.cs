using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponScript : MonoBehaviour
{



    int totalWeapons = 1;

    public int currentWeaponIndex;

    public GameObject[] guns;
    public GameObject weaponHolder;

    public GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {

        totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);
        }

        guns[0].SetActive(true);
        currentGun = guns[0];
        currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 0;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 1;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 2;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            guns[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = 3;
            guns[currentWeaponIndex].SetActive(true);
            currentGun = guns[currentWeaponIndex];

        }



    }
}
