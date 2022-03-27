using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public RipplePostProcessor camRipple;
    public CameraShake cameraShake;
    public GameObject bloodSplatter;
    public GameObject bloodSplash;
    public float fireRes = 10f;
    public float oryginalFireRes;
    public float enemyHealth;
    public ChangeEnemyHealthUI healthbar;
    public bool isOnFire = false;
    private int fireCooldown = 5;
    public int shockRes = 10;
    public int oryginalShockRes;
    public EnemyAI stopIfShocked1 = null;
    public ShotgunEnemyAI stopIfShocked2 = null;
    public GameObject enemy;

    private void Start()
    {
        oryginalFireRes = fireRes;
        oryginalShockRes = shockRes;
        healthbar.SetMaxHealth(enemyHealth);

        enemyCount.instance.enemiesCount++;
    }
    IEnumerator WaitForFireDamage()
    {
        for (int i = 0; i < fireCooldown; i++)
        {
            yield return new WaitForSeconds(1);
            enemyHealth -= 10f;
            if(enemyHealth <= 0)
            {
                DestroyEnemy();
            }
        }
        fireRes = oryginalFireRes;
    }
    IEnumerator ShockStun()
    {
        if(stopIfShocked1 != null)
        {
            stopIfShocked1.isShocked = true;
            yield return new WaitForSeconds(10);
            stopIfShocked1.isShocked = false;
        }
        if (stopIfShocked2 != null)
        {
            stopIfShocked2.isShocked = true;
            yield return new WaitForSeconds(10);
            stopIfShocked2.isShocked = false;
        }
        shockRes = oryginalShockRes;
    }
    private void Update()
    {
        healthbar.SetHealth(enemyHealth);
        if (isOnFire)
        {
            StartCoroutine(WaitForFireDamage());
            isOnFire = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RevolverBullet")
        {
            enemyHealth -= RevolverDamage.instance.damage;
            if(RevolverDamage.instance.fireDamage != 0 && !isOnFire)
            {
                fireRes -= RevolverDamage.instance.fireDamage;
                if(fireRes <= 0)
                {
                    isOnFire = true;
                }
            }
            if(RevolverDamage.instance.shockDamage != 0)
            {
                shockRes -= RevolverDamage.instance.shockDamage;
                if(shockRes <= 0)
                {
                    StartCoroutine(ShockStun());
                }
            }
            if (enemyHealth <= 0)
            {
                DestroyEnemy();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "ShotgunBullet")
        {
            enemyHealth -= ShotgunDamage.instance.damage;
            if (ShotgunDamage.instance.fireDamage != 0 && !isOnFire)
            {
                fireRes -= ShotgunDamage.instance.fireDamage;
                if (fireRes <= 0)
                {
                    isOnFire = true;
                }
            }
            if (ShotgunDamage.instance.shockDamage != 0)
            {
                shockRes -= ShotgunDamage.instance.shockDamage;
                if (shockRes <= 0)
                {
                    StartCoroutine(ShockStun());
                }
            }
            if (enemyHealth <= 0)
            {
                DestroyEnemy();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SMGBullet")
        {
            enemyHealth -= SMGDamage.instance.damage;
            if (SMGDamage.instance.fireDamage != 0 && !isOnFire)
            {
                fireRes -= SMGDamage.instance.fireDamage;
                if (fireRes <= 0)
                {
                    isOnFire = true;
                }
            }
            if (SMGDamage.instance.shockDamage != 0)
            {
                shockRes -= SMGDamage.instance.shockDamage;
                if (shockRes <= 0)
                {
                    StartCoroutine(ShockStun());
                }
            }
            if (enemyHealth <= 0)
            {
                DestroyEnemy();
            }
            Destroy(collision.gameObject);
        }
    }
    private void DestroyEnemy()
    {
        PlayerCoins.instance.numOfCoins += Random.Range(5, 25);
        camRipple.RippleEffect();
        StartCoroutine(cameraShake.Shake(4f, .2f));
        Instantiate(bloodSplash, transform.position, Quaternion.identity);
        Instantiate(bloodSplatter, transform.position, Quaternion.identity);
        Destroy(enemy);
        enemyCount.instance.enemiesCount--;
    }
}
