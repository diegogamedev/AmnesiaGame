using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavenManager : MonoBehaviour
{
    public float speed;
    public float life;
    public GameObject cloudsPrefab;


    void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
        StartCoroutine(SpawnClouds());
    }

    void Update()
    {
        cloudsPrefab.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    IEnumerator SpawnClouds()
    {
        Instantiate(cloudsPrefab);

        Destroy(gameObject, life);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnClouds());
    }

}