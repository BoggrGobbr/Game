using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    [SerializeField] float pickupRadius;
    [SerializeField] int layerMaskNo = 13;
    [SerializeField] bool isHoldingGun = false; public bool IsHoldingGun {  get { return isHoldingGun; } }
    private Pickup currentGun; public Pickup CurrentGun { get { return currentGun; } }
    private GunAim gunPivot;
    void Start()
    {
        gunPivot = GameObject.Find("Gun Pivot").GetComponent<GunAim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canPickup())
        {
            
            if (!isHoldingGun)
            {
                currentGun = getClosestGun();
                Pickup(currentGun);
            }
            else
            {
                Pickup secondGun = getClosestGun();
                Drop(currentGun);
                Pickup(secondGun);
                currentGun = secondGun;
            }
        }

    }

    private void OnDrawGizmos() //draw circle
    {
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }

    private Pickup getClosestGun()
    {
        Collider2D[] gunColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, 1 << layerMaskNo);
        Pickup closestGun = null;
            //take the min distance of the first gun collider that is not held
            float minDistance = (transform.position - (!gunColliders[0].GetComponent<Pickup>().IsHeld? gunColliders[0].transform.position: gunColliders[1].transform.position)).sqrMagnitude;
            //Debug.Log("minDis = " + minDistance);
            closestGun = gunColliders[0].GetComponent<Pickup>();
            for (int i = 0; i < gunColliders.Length; i++)
            {
            //    Debug.Log("\t i: " + i);
            if (!gunColliders[i].GetComponent<Pickup>().IsHeld && (transform.position - gunColliders[i].transform.position).sqrMagnitude <= minDistance)
            {
            //    Debug.Log("closer gun " + i + " at : " + (transform.position - gunColliders[i].transform.position).sqrMagnitude);
                closestGun = gunColliders[i].GetComponent<Pickup>();
            }
            else
                Debug.Log(!gunColliders[i].GetComponent<Pickup>().IsHeld ? "not held" : "held");
            }
        
        //Debug.Log(closestGun == null ? "No Gun" : "Found closest Gun");
        return closestGun;
    }

    private bool canPickup()
    {
        Collider2D[] gunColliders = Physics2D.OverlapCircleAll(transform.position, pickupRadius, 1 << layerMaskNo);
        if (gunColliders.Length != 0)
        {
          //  Debug.Log("Starting check");
            for (int i = 0; i < gunColliders.Length; i++)
            {
             //   Debug.Log("\t check i: " + i);
                if (!gunColliders[i].GetComponent<Pickup>().IsHeld)
                {
                //    Debug.Log("\t found gun");
                    return true;
                }
            }
        }
     //   Debug.Log("No Gun");
        return false;
    }

    private void Pickup(Pickup gun)
    {
        isHoldingGun = true;
        gun.BePickedup();
        gunPivot.CanRotate = true;
        gun.GetComponent<Collider2D>().enabled = false;
    }

    private void Drop(Pickup gun)
    {
        isHoldingGun = false;
        gun.BeDropped();
        gunPivot.CanRotate = false;
        gun.GetComponent<Collider2D>().enabled = true;
    }
}
