using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpikeTrap : MonoBehaviour
{
    [SerializeField] GameObject spikes;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject spikeTrap = Instantiate(spikes, transform.position, transform.rotation);
            spikeTrap.transform.SetParent(transform);
        }

    }
}
