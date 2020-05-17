using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpinnerScript : MonoBehaviour
{
    Quaternion destination;
    public AudioSource rumble;
    public bool spinning;
    public float spinVelocity = 0.1f;

    private void Update()
    {
        //Rotaciona o objeto 
        transform.rotation = Quaternion.RotateTowards(transform.rotation, destination, spinVelocity);
        if (destination == transform.rotation)
        {
            rumble.Stop();
        }
    }

    public void Spin(Vector3 direction)
    {
        destination = Quaternion.Euler(direction);
        rumble.Play();
    }
}
