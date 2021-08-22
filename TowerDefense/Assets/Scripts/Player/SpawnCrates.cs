using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    private Vector3 mousePos;
    public bool click = false;
    public bool isClick = false;
    public GameObject crate;
    public float numberCrates = 4;
    private float checkRadius = 10;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
           click = true;
        if (Input.GetKeyUp(KeyCode.Mouse1))
            click = false;
    }
    
    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var checkResult = Physics.OverlapSphere(mousePos, checkRadius);
        if (checkResult.Length == 0)
        {
            if (click && !isClick && numberCrates > 0)
            {
                GameObject spawnedCrate = Instantiate(crate, mousePos, Quaternion.identity);
                spawnedCrate.transform.position = new Vector3(Mathf.Round(spawnedCrate.transform.position.x),
                                                              Mathf.Round(spawnedCrate.transform.position.y),
                                                              Mathf.Round(spawnedCrate.transform.position.z));
                numberCrates--;

                isClick = true;
            }
        }
        if (!click)
            isClick = false;
    }
}
