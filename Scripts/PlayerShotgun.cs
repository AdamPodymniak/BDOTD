using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float fireRate;
    float ReadyForNextShot;


    [SerializeField] private int NumberOfProjectiles = 6;
    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 40f;

    public float bulletForce;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / fireRate;
                float angleStep = SpreadAngle / NumberOfProjectiles;
                float aimingAngle = firePoint.rotation.eulerAngles.z + 90f;
                float centeringOffset = (SpreadAngle / 2) - (angleStep / 2);                                                                                                                        //centered on the mouse cursor

            for (int i = 0; i < NumberOfProjectiles; i++)
            {
                float currentBulletAngle = angleStep * i;
                    Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
                    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bullet.transform.right * 10, ForceMode2D.Impulse);
            }
            }
        }
    }
}
