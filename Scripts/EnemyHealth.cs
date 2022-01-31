using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public RipplePostProcessor camRipple;
    public CameraShake cameraShake;
    public GameObject bloodSplatter;
    public GameObject bloodSplash;
    public float enemyHealth;
    public ChangeEnemyHealthUI healthbar;

    private void Start()
    {
        healthbar.SetMaxHealth(enemyHealth);

        enemyCount.instance.enemiesCount++;
    }
    
    private void Update()
    {
        healthbar.SetHealth(enemyHealth);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RevolverBullet")
        {
            enemyHealth -= RevolverDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                camRipple.RippleEffect();
                StartCoroutine(cameraShake.Shake(4f, .2f));
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                Instantiate(bloodSplatter, transform.position, Quaternion.identity);
                Destroy(gameObject);
                enemyCount.instance.enemiesCount--;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "ShotgunBullet")
        {
            enemyHealth -= ShotgunDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                camRipple.RippleEffect();
                StartCoroutine(cameraShake.Shake(4f, .2f));
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                Instantiate(bloodSplatter, transform.position, Quaternion.identity);
                Destroy(gameObject);
                enemyCount.instance.enemiesCount--;
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "SMGBullet")
        {
            enemyHealth -= SMGDamage.instance.damage;
            if (enemyHealth <= 0)
            {
                camRipple.RippleEffect();
                StartCoroutine(cameraShake.Shake(4f, .2f));
                Instantiate(bloodSplash, transform.position, Quaternion.identity);
                Instantiate(bloodSplatter, transform.position, Quaternion.identity);
                Destroy(gameObject);
                enemyCount.instance.enemiesCount--;
            }
            Destroy(collision.gameObject);
        }
    }
}
