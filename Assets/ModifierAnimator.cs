using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModifierAnimator : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] float sizeInscrease;
    ModifierApplier modifierButton;
    Text modifierDescription;
    TextMeshProUGUI textbox;
    private void Start()
    {
        modifierButton = GetComponentInChildren<ModifierApplier>();
        textbox = transform.parent.GetComponentInChildren<TextMeshProUGUI>();
        modifierDescription = modifierButton.modifier.GetComponent<Text>();
    }
    public void IncreaseSize()
    {
        transform.localScale += new Vector3 (sizeInscrease / 100,sizeInscrease/100,0);
    }

    public void ResetSize()
    {
        transform.localScale = new Vector3(1, 1, 0);
    }

    public void addDescription()
    {
        textbox.text = modifierDescription.text;
    }

    public void deleteDescription()
    {
        textbox.text = "";
    }
}
