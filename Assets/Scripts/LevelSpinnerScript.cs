using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpinnerScript : MonoBehaviour
{
    Quaternion destination;

    private void Update()
    {
        print(destination == transform.rotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, destination, 0.1f);
    }

    public void Spin(Vector3 direction)
    {
        print("chamei");
        destination = Quaternion.Euler(direction);
    }
}
