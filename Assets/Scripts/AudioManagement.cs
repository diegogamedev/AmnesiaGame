using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    public AudioClip[] clips;
    AudioSource playerAudio;
    public CharacterController character; 
    bool landing;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    void Update()
    {        
        if (!landing)
        {
            if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") && character.isGrounded)
            {
                print("andando");
                playerAudio.clip = clips[0];
                playerAudio.Play();
                playerAudio.loop = true;
            }
            if (Input.GetButtonDown("Jump"))
            {
                print("salto");
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
        print("pouso");
        playerAudio.clip = clips[2];
        playerAudio.Play();
        playerAudio.loop = false;
        yield return new WaitForSeconds(playerAudio.clip.length/2);
        landing = false;
    }
}
