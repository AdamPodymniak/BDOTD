using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public bool isShocked = false;
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
        if (!isShocked)
        {
            if (timeBtwShots <= 0)
            {
                audioSource.Play();
                BulletFollow bullet = Instantiate(enemyBullet, transform.position, Quaternion.identity).GetComponent<BulletFollow>();
                bullet.rb.velocity = bullet.speed * transform.right;
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
