using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndpointDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndPoint"))
        {
            Debug.Log("DESTROY ENDPOINT: room "+ transform.parent.name + "destroyed endpoint "+collision.name + "from "+collision.transform.parent.name);
            Destroy(collision.gameObject);
        }
    }
}
