using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonController : MonoBehaviour
{
    public float range;
    public float fireRate = 100;
    private float oldRate;
    public float bulletForce = 20;

    public GameObject firePoint;
    public GameObject bulletPrefab;

    private Rigidbody2D rb;

    private Vector3 enemyPos;
    private float rotZ;

    private Collider[] colliders;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oldRate = fireRate;
    }

    private void FixedUpdate()
    {   
        if (FindClosestEnemy() != null)
        {
            enemyPos = FindClosestEnemy().transform.position - transform.position;
            enemyPos.Normalize();

            rotZ = Mathf.Atan2(enemyPos.y, enemyPos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

            fireRate--;
            if (fireRate <= 0)
            {
                fireRate = oldRate;
                Shoot();
            }
        }
    }
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = range;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.transform.up * bulletForce, ForceMode2D.Impulse);
    }
}
