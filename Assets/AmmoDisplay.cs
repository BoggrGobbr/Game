using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    GunShot gun;
    GunPickup player;
    [SerializeField] TextMeshProUGUI ammoText;
    GunShot test;
    void Start()
    {
        StartCoroutine("WaitForPlayer");
        ammoText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (player.IsHoldingGun)
        {
            gun = player.CurrentGun.GetComponent<GunShot>();
            ammoText.SetText(gun.Ammo + "/" + gun.MaxAmmo);
        }
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GunPickup>();
    }
}
