using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ShotgunEnemyAI : MonoBehaviour
{
    public bool isShocked;
    public AudioSource audioSource;
    public float stoppingDistance;
    public float retreatDistance;
    public Transform player;
    float angle;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject enemyBullet;

    public Transform target;
    public float speed;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    [SerializeField] private int NumberOfProjectiles = 6;
    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 40f;
    [SerializeField] private Transform ProjectileSpawnPosition;
    public Vector3 dir;
    public float distance = 10f;


    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("UpdatePath", 0f, .5f);

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {

        dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        if (!isShocked)
        {
            if (timeBtwShots <= 0)
            {
                audioSource.Play();
                float angleStep = SpreadAngle / NumberOfProjectiles;
                float aimingAngle = gameObject.transform.rotation.eulerAngles.z;
                float centeringOffset = (SpreadAngle / 2) - (angleStep / 2);                                                                                                                        //centered on the mouse cursor

                for (int i = 0; i < NumberOfProjectiles; i++)
                {
                    float currentBulletAngle = angleStep * i;

                    Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
                    GameObject bullet = Instantiate(enemyBullet, ProjectileSpawnPosition.position, rotation);

                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(bullet.transform.right * 10, ForceMode2D.Impulse);
                }
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            rb.AddForce(force);
        }
        else if ((Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) || isShocked)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            rb.AddForce(-force * 5f);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
