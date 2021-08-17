using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(transform.position.x) - Mathf.Abs(player.transform.position.x) > player.GetComponent<TopDownPlayerController>().bulletRange ||
            Mathf.Abs(transform.position.y) - Mathf.Abs(player.transform.position.y) > player.GetComponent<TopDownPlayerController>().bulletRange)
            Destroy(gameObject);
    }
}
