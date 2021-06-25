using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTeleport : MonoBehaviour
{
    [SerializeField] Transform destination;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (collision.CompareTag("Elevator"))
          {
              Debug.Log("TP");
              collision.transform.position = destination.position;
          } 
    }
}
