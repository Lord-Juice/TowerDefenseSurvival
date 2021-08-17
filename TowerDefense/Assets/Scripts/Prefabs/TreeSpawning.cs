using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawning : MonoBehaviour
{
    public float treeSpawnRate = 3000;
    public float treeTimer;
    public GameObject Tree;
    private Vector3 Spawnrange;
    public float TreeRange = 5;
    public float startTrees = 3;

    private void Start()
    {
        for (int i = 0; i < startTrees; i++)
        {
            Spawnrange = new Vector3(transform.position.x + Random.Range(-TreeRange, TreeRange),
                                 transform.position.y + Random.Range(-TreeRange, TreeRange),
                                 0f);
            Instantiate(Tree, Spawnrange, Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        treeTimer++;
        Spawnrange = new Vector3(transform.position.x + Random.Range(-TreeRange, TreeRange), 
                                 transform.position.y + Random.Range(-TreeRange, TreeRange), 
                                 0f);
        if(treeTimer == treeSpawnRate)
        {
            treeTimer = 0;
            Instantiate(Tree, Spawnrange, Quaternion.identity);
        }
            
    }
}
