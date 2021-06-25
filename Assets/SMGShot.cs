using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class SMGShot : GunShot
    {
        private void Update()
        {
            if (Input.GetMouseButton(0) && gunItem.IsHeld && ammo > 0 && canShoot)
               
            {
                Shoot(firePoint.rotation);
                ammo--;
                canShoot = false;
                StartCoroutine(GunshotDelay());
            }
        }
    }
}
