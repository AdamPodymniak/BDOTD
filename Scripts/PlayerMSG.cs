using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMSG : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireRate;
    float ReadyForNextShot;


    public float bulletForce;
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSource.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            audioSource.Stop();
        }
    }
}
