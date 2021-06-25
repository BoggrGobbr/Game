using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Transform))]
public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector2 offset;
    void Start()
    {
        StartCoroutine("WaitForPlayer");
    }   
    void FixedUpdate()
    {
      //  if(player.position.y>=1)
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
