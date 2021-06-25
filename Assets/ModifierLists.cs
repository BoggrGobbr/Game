using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierLists : MonoBehaviour
{
    [SerializeField] GameObject[] modifiers; public GameObject[] Modifiers { get { return modifiers; } }
    [SerializeField] List<GameObject> activeModifiers; public List<GameObject> ActiveModifiers { get { return activeModifiers; } }
    public bool bulletSin, bulletPull, bulletExplosion, slowBullet, acceleratingBullet;
    [Range(0,100)]public float bulletSinFrequency, bulletSignMagnitude, bulletSpeedPercentage;
}


