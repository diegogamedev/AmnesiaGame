using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWhenCollideScript : MonoBehaviour
{
    public AudioClip[] blocks;
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().clip = blocks[Random.Range(0, blocks.Length)];
        GetComponent<AudioSource>().Play();
    }
}
