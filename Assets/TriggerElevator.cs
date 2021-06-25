using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerElevator : MonoBehaviour
{
    [SerializeField] bool move, hasToStop; public bool Move { get { return move; } }
    [SerializeField] float elevatorSpeed, stopPositionY;
    Transform elevator;
    [SerializeField] public static bool playerInput = true;

    private void Start()
    {
        elevator = transform.parent;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            if (!hasToStop)
            {
                move = true;
                collision.transform.SetParent(transform);
                playerInput = false;
            }
            else
                playerInput = true;
    }

    private void FixedUpdate()
    {
        if (hasToStop && elevator.position.y >= stopPositionY)
        {
            move = false;
            
        }
        if (move)
            elevator.Translate(new Vector3(0, elevatorSpeed * Time.deltaTime, 0));
        

    }
}
