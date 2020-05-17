using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animation anim;
    Animator animator;
    bool jumpAnimRunning;

    void Start()
    {
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
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

        if (Input.GetMouseButton(0))
            animator.SetBool("ActiveCamera", true);
        else
            animator.SetBool("ActiveCamera", false);
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
