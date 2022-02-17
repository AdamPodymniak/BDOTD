using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject playerPref;
    public Transform[] startingPositions;
    public GameObject[] rooms;
    public Camera cam;
    public Healtbar healthbar;
    public PlayerStats playerHealth;

    private int direction;
    public float moveAmount;

    public float minX;
    public float maxX;
    public float minY;

    public bool stopGeneration = false;

    public LayerMask room;

    int downCounter = 0;

    private void Start()
    {
        int randStartingPos = Random.Range(0, 4);
        transform.position = startingPositions[randStartingPos].position;
        GameObject player = Instantiate(playerPref, transform.position, Quaternion.identity);
        player.GetComponent<PlayerMovement>().cam = cam;
        player.GetComponent<PlayerHealth>().healthBar = healthbar;
        player.GetComponent<PlayerHealth>().healtStat = playerHealth;
        player.GetComponentInChildren<LewitacjaBroni>().cam = cam;
        Instantiate(rooms[3], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);
    }
    private void Update()
    {
        if (!stopGeneration)
        {
            Move();
        }
    }
    private void Move()
    {
        if(direction == 1 || direction == 2)
        {
            downCounter = 0;
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
                if (direction == 3)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        } else if (direction == 3 || direction == 4)
        {
            downCounter = 0;
            if(transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }else
            {
                direction = 5;
            }
        }
        else
        {
            downCounter++;
            if(transform.position.y > minY)
            {
                Collider2D roomDetector = Physics2D.OverlapCircle(transform.position, 1, room);
                if(roomDetector.GetComponent<RoomType>().type != 1 && roomDetector.GetComponent<RoomType>().type!= 3)
                {
                    if(downCounter >= 2)
                    {
                        roomDetector.GetComponent<RoomType>().RoomDestroyer();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetector.GetComponent<RoomType>().RoomDestroyer();
                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                stopGeneration = true;
            }
        }
    }
}
