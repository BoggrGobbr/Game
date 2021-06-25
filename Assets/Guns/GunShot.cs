using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    public Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] protected float shootPushSpeed = 2f, gunshotDelay = 0.5f;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] [Range(0,5)] int framesToFlash = 5;
    protected bool isFlashing = false, canShoot = true;
    [SerializeField] PlayerInput player;
    [SerializeField] protected Pickup gunItem; 
    [SerializeField] protected int maxAmmo, ammo;
    [SerializeField] ModifierLists modifiers;
    public int Ammo { set { ammo = value; } get { return ammo; } }
    public int MaxAmmo { get { return maxAmmo; } }
    void Start()
    {
        ammo = maxAmmo;
        gunItem = gameObject.GetComponent<Pickup>();
        player = GameObject.Find("Player").GetComponent<PlayerInput>();
        firePoint = transform.Find("Fire Point");
        muzzleFlash = transform.Find("Muzzle Flash").gameObject;
        modifiers = GameObject.Find("Modifiers").GetComponent<ModifierLists>();

        if (muzzleFlash!=null)
        {
            muzzleFlash.SetActive(false);
        }
    }

    public virtual void Shoot(Quaternion rotation)
    {
        if(!isFlashing)
            StartCoroutine(DoFlash());
        Instantiate(bulletPrefab, firePoint.position, rotation);
        if (modifiers.bulletPull)
        {
            player.shootVelocity.y += Mathf.Sin((rotation.eulerAngles.z) * Mathf.Deg2Rad) * shootPushSpeed;
            player.shootVelocity.x += Mathf.Cos((rotation.eulerAngles.z) * Mathf.Deg2Rad) * shootPushSpeed;
        }
        else
        {
            player.shootVelocity.y += Mathf.Sin((rotation.eulerAngles.z + 180) * Mathf.Deg2Rad) * shootPushSpeed;
            player.shootVelocity.x += Mathf.Cos((rotation.eulerAngles.z + 180) * Mathf.Deg2Rad) * shootPushSpeed;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunItem.IsHeld && ammo>0 && canShoot && TriggerElevator.playerInput) 
        {
            Shoot(firePoint.rotation);
            ammo--;
            canShoot = false;
            StartCoroutine(GunshotDelay());
        }
    } 


    protected IEnumerator DoFlash()
    {
        muzzleFlash.SetActive(true);
        isFlashing = true;
        int framesFlashed = 0;
        while (framesFlashed <= framesToFlash)
        {
            framesFlashed++;
            yield return null;
        }
        muzzleFlash.SetActive(false);
        isFlashing = false;
    }

    protected IEnumerator GunshotDelay()
    {
        yield return new WaitForSeconds(gunshotDelay);
        canShoot = true;
    }
}
