using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CameraManager : MonoBehaviour
{
    private Transform lookAt;
    private float transition = 0;
    private float animDuration = 3.0f;
    private Vector3 startPosition, moveVector;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position - lookAt.position;
        StartCoroutine(Gameover());
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = lookAt.position + startPosition;

        moveVector.x = 0;

        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);

        if(transition > 1)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animDuration;
            //transition.LookAt(lookAt.position + Vector3.up);
        }
        
    }

    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3.0f);
    }
}
