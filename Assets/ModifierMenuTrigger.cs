using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierMenuTrigger : MonoBehaviour
{
    [SerializeField] GameObject modifierMenu;

    private void Start()
    {
        modifierMenu = GameObject.Find("Canvas").transform.Find("Modifier Menu").gameObject;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("MENU");
            modifierMenu.SetActive(true);
        }
    }
}
