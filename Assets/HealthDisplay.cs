using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    HpSystem player;
    [SerializeField] TextMeshProUGUI healthText;
    void Start()
    {
        StartCoroutine("WaitForPlayer");
        healthText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText("HP: " + player.Hp);
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForEndOfFrame();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HpSystem>();
    }
}
