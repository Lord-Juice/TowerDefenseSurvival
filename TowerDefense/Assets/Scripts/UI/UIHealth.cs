using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHealth : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string playerHP;

    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        playerHP = player.GetComponent<TopDownPlayerController>().health.ToString();
        playerHP = "Health: " + playerHP;

        textMeshPro.text = playerHP;
    }
}
