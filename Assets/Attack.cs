using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] BoxCollider2D enemyCollider;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] HpSystem player;
    [SerializeField] int collisionDamage; 

    void Start()
    {
        enemyCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HpSystem>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            int knockbackDirection = (transform.position.x > col.transform.position.x?-1:1); //knock the player back in the opposite direction

            if (transform.position.x == col.transform.position.x)  //only knock the player upwards when on top of eachother
                knockbackDirection = 0;
            
            player.TakeDamage(collisionDamage,knockbackDirection);
        }
    }
}
