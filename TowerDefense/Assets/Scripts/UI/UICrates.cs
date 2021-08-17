using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICrates : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    private string crates;

    private GameObject player;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();

        player = GameObject.Find("Player");
    }

    private void Update()
    { 
        crates = player.GetComponent<SpawnCrates>().numberCrates.ToString();
        crates = "Crates: " + crates;
        textMeshPro.SetText(crates);
    }
}
