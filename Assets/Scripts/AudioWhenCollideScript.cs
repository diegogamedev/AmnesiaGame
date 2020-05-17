using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioWhenCollideScript : MonoBehaviour
{
    public AudioClip[] blocks;
    AudioSource audioSource;
    Rigidbody rb;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = blocks[Random.Range(0, blocks.Length)];
        audioSource.Play();     
    }
}
