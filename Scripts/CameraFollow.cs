using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;

    public float speed;

    public Vector3 offset;
    void FixedUpdate()
    {
        try
        {
            transform.position = Vector3.Lerp(transform.position, player.position, speed) + offset;
        }
        catch { }
    }
}
