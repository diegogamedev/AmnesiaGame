using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float verticalVelocity;
    public float impulseJump;
    public float gravity;

    public static bool endGame, land, gameover = false;

    public Vector3 moveVector;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            land = true;

        moveVector = Vector3.zero;

        if (Input.GetButton("Jump"))
        {
            if (controller.isGrounded)
            {
                verticalVelocity = Mathf.Sqrt(impulseJump * -1 * gravity);
            }
        }

        if (verticalVelocity >= -11f)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }


        moveVector.x = Input.GetAxis("Horizontal") * speed;
        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }


    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.CompareTag("SpawnedPrefab"))
        {
            gameover = true;
            SceneManager.LoadScene("FaseFinal");
        }
        if (c.gameObject.CompareTag("EndGame"))
        {
            endGame = true;
            speed = 2;
        }
    }
}

