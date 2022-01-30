using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LewitacjaBroni : MonoBehaviour
{



    [SerializeField]
    Transform player;

    public float speed;

    public Vector3 offset;
    public Rigidbody2D rb;
    public Camera cam;
    

    Vector2 mousePos;
    
    void Update()
    {
        

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    }
    private void FixedUpdate()
    {
        

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;



        try
        {
            transform.position = Vector3.Lerp(transform.position, player.position, speed) + offset;
        }
        catch { }
    }



    
    
}
