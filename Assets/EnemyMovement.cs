using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMovement : MonoBehaviour
{
    [SerializeField] protected float gravity;
    [SerializeField] protected Vector3 velocity;
    [SerializeField] protected LayerMask collisionMask;
    [SerializeField] protected Raycast controller;
    [SerializeField] protected float speed;
    protected bool facingRight = true;

    
    protected virtual void Start()
    {
        controller = GetComponent<Raycast>();
    }
    protected void Flip()
    {
        facingRight = !facingRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
