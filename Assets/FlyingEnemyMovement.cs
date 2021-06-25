using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMovement : EnemyMovement
{
    [SerializeField] float triggerRadius;
    [SerializeField] bool isIdle = true;
    Transform player;
    Animator animator;

    protected override void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        base.Start();
    } 

    private void Update()
    {
        if (isIdle == false)
        {
            Vector2 batPosition = transform.position, playerPosition = player.position;
            velocity.x = playerPosition.x - batPosition.x;
            velocity.y = playerPosition.y - batPosition.y;
            velocity = velocity.normalized*speed;

            if ((velocity.x > 0 && !facingRight) || (velocity.x < 0 && facingRight))
                Flip();

            controller.Move(velocity * Time.deltaTime);
        }
        

    }

    private void OnDrawGizmos() //draw circle
    {
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isIdle == true && collision.CompareTag("Player"))
        {
            isIdle = false;
            animator.Play("bat_fly");
        }
        
        

    }

}
