using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > ReadyForNextShot)
            {
                audioSource.Play();
                ReadyForNextShot = Time.time + 1 / fireRate;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            }
        }
    }
}
