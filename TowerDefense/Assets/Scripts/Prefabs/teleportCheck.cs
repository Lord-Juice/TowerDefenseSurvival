using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportCheck : MonoBehaviour
{
    private bool isColliding;
    public GameObject cratePrefab;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isColliding = true;
    }

    private void Update()
    {
        if (!isColliding)
        {
            Instantiate(cratePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
