using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObjectsConfig : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject[] spawnedPrefabs;
    [SerializeField] private float groundLength;

    private List<GameObject> activeTiles = new List<GameObject>();

    private float spawnZ = 0;
    private int groundsOnScreen = 4;
    private bool first;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < groundsOnScreen; i++)
        {
            if (i == 0)
            {
                first = true;
                SpawnGround(0);
            }
            else
                first = false;
                SpawnGround(Random.Range(0, spawnedPrefabs.Length));
        }
    }

    void Update()
    {
        if(playerTransform.position.z > spawnZ - (groundsOnScreen * groundLength))
        {
            SpawnGround(Random.Range(0, spawnedPrefabs.Length));
            if(!first)
                DeleteTile();
        }
    }

    void SpawnGround(int groundIndex)
    {
        GameObject ground = Instantiate(spawnedPrefabs[groundIndex], transform.forward * spawnZ, transform.rotation);
        activeTiles.Add(ground);
        spawnZ += groundLength;
        
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void SpawnObjects()
    {
        float raffle = Random.Range(-1000, 1000);

        if (raffle > 0)
        {
            //Instantiate(objects[0], coordernada, transform.rotation);
        }
        else
        {
            //Instantiate(objects[1], coordernada, transform.rotation);
        }
    }
}





