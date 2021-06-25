using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonAnimator : MonoBehaviour
{ 
    [SerializeField] [Range(0,100)] float sizeIncrease = 50;

    float oldSize;
    [SerializeField] TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void ChangeSize()
    {
        
        oldSize = text.fontSize;
        text.fontSize = text.fontSize * (1 + sizeIncrease / 100);
        Debug.Log("old: " + oldSize + " new: " + text.fontSize);
    }

    public void RevertSize()
    {
        text.fontSize = oldSize;
    }


}
