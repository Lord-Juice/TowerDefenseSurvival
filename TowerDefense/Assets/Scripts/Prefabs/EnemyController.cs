using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb;
    private float rotZ;
    public float enemyHealth = 90;

    private bool inRange;
    private float rangeX;
    private float rangeY;
    private float range;

    private GameObject player;
    private TopDownPlayerController controller;

    Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        controller = player.GetComponent<TopDownPlayerController>();
        range = controller.playerRange;
    }
    
    private void FixedUpdate()
    {
        moveDir = player.transform.position - transform.position;
        moveDir.Normalize();

        rotZ = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        rb.velocity = new Vector2(moveDir.x * speed, moveDir.y * speed);

        rangeX = transform.position.x - player.transform.position.x;
        rangeY = transform.position.y - player.transform.position.y;

        if (Mathf.Abs(rangeX) < range && Mathf.Abs(rangeY) < range)
            inRange = true;
        else
            inRange = false;

        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            GameObject.Find("Killcount").GetComponent<UIKillCount>().killCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
            enemyHealth -= 30;
    }
}
