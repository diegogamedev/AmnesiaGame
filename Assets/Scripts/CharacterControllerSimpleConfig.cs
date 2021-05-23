using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterControllerSimpleConfig : MonoBehaviour
{
    public float speed;
    public float impulseJump;
    public float gravity;
    public GameObject video;
    public AudioManagement audioObject;

    public Vector3 moveDirection;
    public Vector3 verticalDirection;
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.right * x + transform.forward * z;

        controller.Move(moveDirection * speed * Time.deltaTime);

        if (Input.GetButton("Jump"))
        {
            if (controller.isGrounded)
            {
                verticalDirection.y = Mathf.Sqrt(impulseJump * -2 * gravity);
            }
        }

        if (verticalDirection.y >= -11f)
        {
            verticalDirection.y += gravity * Time.deltaTime;
        }

        controller.Move(verticalDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Gameover"))
        {
            SceneManager.LoadScene("Fase3");
        }


        if (other.gameObject.CompareTag("Portal"))
        {
            StartCoroutine(Video("FaseFinal"));
        }


        if (other.gameObject.CompareTag("Fase3"))
        {
            StartCoroutine(Video("Fase3"));
        }

        if (other.gameObject.CompareTag("Fase2"))
        {
            StartCoroutine(Video("Fase2"));
        }

        StartCoroutine(audioObject.LandingSound());
    }

    IEnumerator Video(string fase)
    {
        yield return new WaitForSeconds(3f);
        video.SetActive(true);
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene(fase);
    }
}
