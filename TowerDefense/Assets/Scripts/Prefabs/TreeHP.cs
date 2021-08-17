using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHP : MonoBehaviour
{
    public float treeHealth = 100;
    public float enemyDamage = 10;
    
    public bool inRange;
    public float rangeX;
    public float rangeY;
    private float range;
    
    private GameObject player;
    private TopDownPlayerController controller;
    private SpawnCrates SpawnCrates;
    private GameObject[] items;
    private float curItem;

    private void Start()
    {
        player = GameObject.Find("Player");
        controller = player.GetComponent<TopDownPlayerController>();
        range = controller.playerRange;

        SpawnCrates = player.GetComponent<SpawnCrates>();
    }

    private void FixedUpdate()
    {
        if (treeHealth == 0)
        {
            Destroy(gameObject);
            SpawnCrates.numberCrates++;
        } 
        
        rangeX = transform.position.x - player.transform.position.x;
        rangeY = transform.position.y - player.transform.position.y;

        if (Mathf.Abs(rangeX) < range && Mathf.Abs(rangeY) < range)
            inRange = true;
        else
            inRange = false;

        curItem = GameObject.Find("Turning Point").GetComponent<SwitchWeapons>().curItem;
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && inRange && curItem == 0)
        {
            treeHealth -= 50;
        }
    }
}
