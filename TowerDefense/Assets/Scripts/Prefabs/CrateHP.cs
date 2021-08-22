using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateHP : MonoBehaviour
{
    public float crateHealth = 100;
    public float enemyDamage = 20;

    private void FixedUpdate()
    {
        if (crateHealth == 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            crateHealth -= enemyDamage;
    }
}
