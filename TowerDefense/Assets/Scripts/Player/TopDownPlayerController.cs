using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float inputX;
    private float inputY;
    public float health = 100;
    public bool dead;

    public float bulletRange = 100;

    public float playerRange;

    private SpriteRenderer renderer;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX * speed, inputY * speed);

        if (GameObject.Find("Turning Point").GetComponent<Rigidbody2D>().rotation < -90 || 
            GameObject.Find("Turning Point").GetComponent<Rigidbody2D>().rotation > 90)
            renderer.flipX = true;
        else
            renderer.flipX = false;
    }

    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");

        if (health <= 0)
        {
            dead = true;
            Destroy(gameObject);
        }
        else
            dead = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            health -= 1;
    }
}
