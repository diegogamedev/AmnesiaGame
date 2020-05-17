using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource playerAudio;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            playerAudio.clip = clips[0];
            playerAudio.Play();
            playerAudio.loop = true;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            playerAudio.clip = clips[1];
            playerAudio.Play();
            playerAudio.loop = false;
        }
        else if (!Input.anyKey)
        {
            playerAudio.Stop();
        }
    }
}
