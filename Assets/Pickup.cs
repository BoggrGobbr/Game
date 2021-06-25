using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] bool pickupAllowed = false;
    
    [SerializeField] LayerMask playerLayer;
    
    [SerializeField] private bool isHeld = false; public bool IsHeld {get { return isHeld;}}
    [SerializeField] GameObject gunPivot, player;
    [SerializeField] float distance;

    void Start()
    {
        gunPivot = GameObject.Find("Gun Pivot");
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if(!isHeld)
            distance = (player.transform.position - transform.position).sqrMagnitude;
    }
    public void BePickedup() 
    {

        isHeld = true;
    
        
        transform.SetParent(gunPivot.transform);
        transform.rotation = gunPivot.transform.rotation;
        transform.localPosition = new Vector2();

     
        Vector2 temp = transform.localScale;
        temp.y *= gunPivot.transform.localScale.y;
        transform.localScale = temp;

    }



    public void BeDropped() 
    {
        isHeld = false;
        transform.parent = null;
        transform.rotation = Quaternion.identity; //reset gun rotation


        Vector2 temp = transform.localScale;
        temp.y*= gunPivot.transform.localScale.y; //reset the gun's scale 
        transform.localScale = temp;

    }
}
