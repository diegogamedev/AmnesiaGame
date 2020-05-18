using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadSpawner : MonoBehaviour
{
    public List<GameObject> Pessoas;
    public Transform spawnPoint;
    public float spaceBetweenHeads;
    float reset;
    Vector3 headSpawn;

    private void OnMouseEnter()
    {
        reset = spaceBetweenHeads;
        headSpawn = spawnPoint.position;
        foreach (GameObject pessoa in Pessoas)
        {
            Instantiate(pessoa, headSpawn, Quaternion.identity, transform);
            headSpawn.x += spaceBetweenHeads;
            spaceBetweenHeads *= -2;
        }
        spaceBetweenHeads = reset;
    }

    private void OnMouseExit()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
