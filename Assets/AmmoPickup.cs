using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] LayerMask ammoLayer;
    [SerializeField] BoxCollider2D playerCollider;
    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
    }

    void OnCollisionEnter2D(Collision2D Ammo)
    {
        if (Ammo.gameObject.tag == "Ammo" && playerCollider.GetComponent<GunPickup>().IsHoldingGun)
        {
            int gunMaxAmmo = GetComponent<GunPickup>().CurrentGun.GetComponent<GunShot>().MaxAmmo, ammo = GetComponent<GunPickup>().CurrentGun.GetComponent<GunShot>().Ammo;
            if (ammo < gunMaxAmmo)
            {
                GetComponent<GunPickup>().CurrentGun.GetComponent<GunShot>().Ammo = gunMaxAmmo;
                Destroy(Ammo.gameObject);
            }           
        }
    }
}
