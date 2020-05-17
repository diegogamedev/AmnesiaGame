using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource playerAudio;

    bool landing;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        if (!landing)
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

    public IEnumerator LandingSound()
    {
        landing = true;
        playerAudio.clip = clips[2];
        playerAudio.Play();
        playerAudio.loop = false;
        yield return new WaitForSeconds(playerAudio.clip.length);
        landing = false;
    }
}
