using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRoom : MonoBehaviour
{
    public GameObject spawnWalls;
    public GameObject spawnObjects;
    public Transform[] enemiesLocations;
    public GameObject shotgunVariantSlow;
    public GameObject shotgunVariantFast;
    public GameObject sniperVariant;
    public GameObject smgVariant;
    GameObject enemy;
    GameObject player;
    GameObject cam;
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spawnWalls.SetActive(true);
            for (int i = 0; i < enemiesLocations.Length; i++)
            {
                int randomEnemy = Random.Range(0, 6);
                if (randomEnemy == 0)
                {
                    enemy = Instantiate(shotgunVariantFast, new Vector3(enemiesLocations[i].position.x, enemiesLocations[i].position.y, 0f), Quaternion.identity);
                    enemy.transform.Find("Shotgun fast").gameObject.GetComponent<ShotgunEnemyAI>().player = player.transform;
                    enemy.transform.Find("Shotgun fast").gameObject.GetComponent<ShotgunEnemyAI>().target = player.transform;
                    enemy.transform.Find("Shotgun fast").gameObject.GetComponent<EnemyHealth>().cameraShake = cam.GetComponent<CameraShake>();
                    enemy.transform.Find("Shotgun fast").gameObject.GetComponent<EnemyHealth>().camRipple = cam.GetComponent<RipplePostProcessor>();
                }
                else if (randomEnemy == 1)
                {
                    enemy = Instantiate(shotgunVariantSlow, new Vector3(enemiesLocations[i].position.x, enemiesLocations[i].position.y, 0f), Quaternion.identity);
                    enemy.transform.Find("Shotgun Variant").gameObject.GetComponent<ShotgunEnemyAI>().player = player.transform;
                    enemy.transform.Find("Shotgun Variant").gameObject.GetComponent<ShotgunEnemyAI>().target = player.transform;
                    enemy.transform.Find("Shotgun Variant").gameObject.GetComponent<EnemyHealth>().cameraShake = cam.GetComponent<CameraShake>();
                    enemy.transform.Find("Shotgun Variant").gameObject.GetComponent<EnemyHealth>().camRipple = cam.GetComponent<RipplePostProcessor>();
                }
                else if (randomEnemy == 2 || randomEnemy == 3)
                {
                    enemy = Instantiate(sniperVariant, new Vector3(enemiesLocations[i].position.x, enemiesLocations[i].position.y, 0f), Quaternion.identity);
                    enemy.transform.Find("Sniper").gameObject.GetComponent<EnemyAI>().player = player.transform;
                    enemy.transform.Find("Sniper").gameObject.GetComponent<EnemyAI>().target = player.transform;
                    enemy.transform.Find("Sniper").gameObject.GetComponent<EnemyHealth>().cameraShake = cam.GetComponent<CameraShake>();
                    enemy.transform.Find("Sniper").gameObject.GetComponent<EnemyHealth>().camRipple = cam.GetComponent<RipplePostProcessor>();
                }
                else if (randomEnemy == 4 || randomEnemy == 5)
                {
                    enemy = Instantiate(smgVariant, new Vector3(enemiesLocations[i].position.x, enemiesLocations[i].position.y, 0f), Quaternion.identity);
                    enemy.transform.Find("SMG").gameObject.GetComponent<EnemyAI>().player = player.transform;
                    enemy.transform.Find("SMG").gameObject.GetComponent<EnemyAI>().target = player.transform;
                    enemy.transform.Find("SMG").gameObject.GetComponent<EnemyHealth>().cameraShake = cam.GetComponent<CameraShake>();
                    enemy.transform.Find("SMG").gameObject.GetComponent<EnemyHealth>().camRipple = cam.GetComponent<RipplePostProcessor>();
                }
            }
        }
        Destroy(spawnObjects);
    }
}
