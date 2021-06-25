using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFall : Fall
{
    [SerializeField] Pickup gunItem;
    void Start()
    {
     
        gunItem = gameObject.GetComponent<Pickup>();
    }

    void Update()
    {
        if (!gunItem.IsHeld)
        {
            DoFall();
        }
    }
}
