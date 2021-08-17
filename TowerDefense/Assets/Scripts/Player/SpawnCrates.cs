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
        if (click && !isClick && numberCrates > 0)
        {
            Instantiate(crate, mousePos, Quaternion.identity);
            numberCrates--;

            isClick = true;
        }
        if (!click)
            isClick = false;
    }
}
