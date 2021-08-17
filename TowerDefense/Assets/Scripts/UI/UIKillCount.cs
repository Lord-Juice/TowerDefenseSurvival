using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIKillCount : MonoBehaviour
{
    public float killCount;
    private TextMeshProUGUI textMeshPro;
    private string kills;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        kills = killCount.ToString();
        kills = "Enemies slaughtered: " + kills;
        textMeshPro.SetText(kills);
    }
}
