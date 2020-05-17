using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadSpawner : MonoBehaviour
{
    public List<GameObject> Pessoas;
    public Transform spawnPoint;

    private void OnMouseEnter()
    {
        foreach(GameObject pessoa in Pessoas)
        {
            Instantiate(pessoa, spawnPoint.position, Quaternion.identity, transform);
        }
    }

    private void OnMouseExit()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
