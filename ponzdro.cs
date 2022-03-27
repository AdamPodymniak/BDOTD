using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ponzdro : MonoBehaviour
{
    public Transform EnemyTransform;
    public Animator EnemyAnimations;

    float EnemyDirectionX;
    float EnemyDirectionY;
    Vector2 EnemyDirection;
    public Animator animator;
    public Rigidbody2D rb;
    public ShotgunEnemyAI dir;
    
    private void Start()
    {



    }







    void Update()
    {
        

            EnemyDirectionX = dir.dir.x;
            EnemyDirectionY = dir.dir.y;
        

        //EnemyDirection = new Vector2(EnemyTransform.position.x, EnemyTransform.position.y);

        //EnemyDirectionX= EnemyDirection.normalized.x;
        //EnemyDirectionY= EnemyDirection.normalized.y;


        //Debug.Log(EnemyDirectionX);
        //Debug.Log(EnemyDirectionY);


        // EnemyAnimations = GetComponent<Animator>();




        









        if (EnemyDirectionX == 0)
        {

            if (EnemyDirectionY >= 0.01)
            {

                animator.SetFloat("Horizontal", 0f);
                animator.SetFloat("Vertical", 0.01f);
                animator.SetFloat("Speed", 1f);


            }



        }
        else if (EnemyDirectionX >= 0.01 && EnemyDirectionY == 0)
        {


            animator.SetFloat("Horizontal", 0.01f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", 1f);







        }
        else if (EnemyDirectionX < 0 && EnemyDirectionY == 0)
        {

            animator.SetFloat("Horizontal", -0.01f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", 1f);

        }
        else if (EnemyDirectionX == 0 && EnemyDirectionY < 0)
        {
            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", -0.01f);
            animator.SetFloat("Speed", 1f);


        }
        else if (EnemyDirectionX < 0 && EnemyDirectionY < 0)
        {

            animator.SetFloat("Horizontal", -0.01f);
            animator.SetFloat("Vertical", -0.01f);
            animator.SetFloat("Speed", 1f);

        }
        else if (EnemyDirectionX <= 0.01 && EnemyDirectionY >= 0.01)
        {

            animator.SetFloat("Horizontal", 0.01f);
            animator.SetFloat("Vertical", 0.01f);
            animator.SetFloat("Speed", 1f);

        }
        else if (EnemyDirectionX >= 0.01 && EnemyDirectionY < 0)
        {

            animator.SetFloat("Horizontal", 0.01f);
            animator.SetFloat("Vertical", -0.01f);
            animator.SetFloat("Speed", 1f);

        }
        else if (EnemyDirectionX < 0 && EnemyDirectionY >= 0.01)
        {

            animator.SetFloat("Horizontal", -0.01f);
            animator.SetFloat("Vertical", 0.01f);
            animator.SetFloat("Speed", 1f);

        }
        else if (EnemyDirectionX == 0 && EnemyDirectionY == 0)
        {

            animator.SetFloat("Horizontal", 0f);
            animator.SetFloat("Vertical", 0f);
            animator.SetFloat("Speed", 0f);

        }






    }






}
