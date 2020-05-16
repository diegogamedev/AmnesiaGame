using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpinnerScript : MonoBehaviour
{
    Quaternion destination;

    private void Update()
    {
        transform.rotation = Quaternion.RotateTowards(transform.position, )
    }

    public void Spin(Vector3 direction)
    {
        destination = Quaternion.Euler(direction);
    }
}
