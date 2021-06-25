using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierApplier : MonoBehaviour
{
    public GameObject modifier;
    ModifierLists modifiers;

    private void Start()
    {
        modifiers = GameObject.Find("Modifiers").GetComponent<ModifierLists>();
    }
    public void ApplyModifier()
    {
        switch (modifier.name)
        {
            case "Sounds Attractive":
                modifiers.bulletPull = true; break;

        }
    }
}
