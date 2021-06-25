using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMovement : EnemyMovement
{
    [SerializeField] Transform edgeCheckRayOriginRight, edgeCheckRayOriginLeft;

    private void Start()
    {
        velocity.x = speed;
    }

    public void Update()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        if (controller.collisions.left || controller.collisions.right)
        {
            velocity.x*=-1;
            Flip();

        }
        CheckForEdge();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);     
    }

    void CheckForEdge()
    {
       
        if(controller.collisions.below)
        {           
            RaycastHit2D edgeCheckRayRight = Physics2D.Raycast(edgeCheckRayOriginRight.position, Vector2.down, 1f, collisionMask);
            Debug.DrawRay(edgeCheckRayOriginRight.position, Vector2.down, Color.red);
            if (!edgeCheckRayRight)
            {
                float temp = velocity.x;
                Flip();
                velocity.x = temp;
                velocity.x *= -1;
                
            }
        }
        
    }

}

