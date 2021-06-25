using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShot : GunShot
{
    [SerializeField] int bulletCount = 3;
    [SerializeField][Range(0,180)] float AngleOffsetRange;
    public override void Shoot(Quaternion rotation)
    {
        float angleOffset = AngleOffsetRange / 2, addedOffset = AngleOffsetRange/(bulletCount-1), currentAngleOffset = -angleOffset;

        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion offsetRotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + currentAngleOffset); 
            base.Shoot(offsetRotation);
            currentAngleOffset += addedOffset;
        }

    }


}
