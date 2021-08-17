using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy;
    private Transform player;
    public float enemySpawnrate = 2000;
    public float timer;

    private Vector2 randomNumbers;

    private float ran1;
    private float ran2;

    Vector3 enemySpawnPosition;

    private void Start()
    {
        player = GetComponent<Transform>();
    }

    private void Update()
    {
        timer++;
        ran1 = Random.Range(-20, -15);
        ran2 = Random.Range(15, 20);
        enemySpawnPosition = new Vector3(
            player.position.x + Random.Range(ran1, ran2),
            player.position.y + Random.Range(ran1, ran2), 
            player.position.z);
        if(timer == enemySpawnrate)
        {
            timer = 0;
            Instantiate(enemy, enemySpawnPosition, Quaternion.identity);
        }
    }
}
