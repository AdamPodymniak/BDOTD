using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
