using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpinnerScript : MonoBehaviour
{
    Quaternion destination;
    public AudioSource rumble;
    public bool spinning;

    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, destination, 0.1f);
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
