using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICreateHealth : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public GameObject Crate;
    public string crateHP;
    private CrateHP crateScript;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        crateScript = Crate.GetComponent<CrateHP>();
    }

    private void Update()
    {
        crateHP = crateScript.crateHealth.ToString();
        textMeshPro.SetText(crateHP);
    }
}
