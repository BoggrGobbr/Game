using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModifierOptions : MonoBehaviour
{
    [SerializeField] int modifierNumber;
    [SerializeField] GameObject prefab;
    ModifierLists modifierLists;
    RectTransform rt;
    void Start()
    {
        rt = GetComponent<RectTransform>();

        for (int i = 1; i <= modifierNumber; i++)
        {
            Debug.Log("creating button " + i);
            Vector2 position = new Vector2(-rt.sizeDelta.x / 2 + (rt.sizeDelta.x / (modifierNumber + 1)) * i, 0);
            Debug.Log(" modifier " + i + " pos: " + position);
            prefab = Instantiate(prefab, transform);
            prefab.transform.localPosition = position;

            Image buttonImage = prefab.GetComponentInChildren<Image>();
            ModifierApplier modifierButton = prefab.GetComponent<ModifierApplier>();

            modifierLists = GameObject.Find("Modifiers").GetComponent<ModifierLists>();
            int random = UnityEngine.Random.Range(0, modifierLists.Modifiers.Length);

            GameObject chosenModifier = modifierLists.Modifiers[random];
            buttonImage.sprite = chosenModifier.GetComponent<SpriteRenderer>().sprite;
            modifierButton.modifier = chosenModifier;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
