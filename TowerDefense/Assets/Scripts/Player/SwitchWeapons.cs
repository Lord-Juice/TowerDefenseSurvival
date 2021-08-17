using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    public GameObject[] items;
    public int curItem = 0;
    private int oldItem;

    private float newTimer;

    private void Start()
    {
        newTimer = 150;
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);
        }

        items[0].SetActive(true);
    }

    private void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") !=0 && newTimer >= 150)
        {
            items[curItem].SetActive(true);
            items[oldItem].SetActive(false);
            
            oldItem = curItem;

            if (curItem == items.Length - 1)
                curItem = 0;
            else
                curItem++;

            newTimer = 0;
        }

        newTimer++;
        
    }
}
