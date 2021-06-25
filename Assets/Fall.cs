using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [SerializeField] Vector3 velocity;
    [SerializeField] Raycast controller;
    [SerializeField] float gravity;
    
    void Start()
    {
        controller = GetComponent<Raycast>();
    }

    void Update()
    {
        DoFall();
    }

    protected void DoFall()
    {
        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

}
