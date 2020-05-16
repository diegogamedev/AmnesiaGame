using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animation anim;
    bool jumpAnimRunning;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumpAnimRunning)
        {
            if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
            {
                anim.CrossFade("Run");

                if (Input.GetButton("Jump"))
                {
                    StartCoroutine(playJumpAnimation("RunAndJump"));
                }
            }
            if (Input.GetButton("Jump"))
            {
                StartCoroutine(playJumpAnimation("RunAndJump"));
            }
            if (!Input.anyKey)
            {
                anim.CrossFade("idle");
            }
        }
    }

    IEnumerator playJumpAnimation(string animname)
    {
        jumpAnimRunning = true;
        float timeToWait;

        anim.CrossFade(animname);
        timeToWait = anim.GetClip(animname).length;

        yield return new WaitForSeconds(timeToWait);
        jumpAnimRunning = false;
    }
}
