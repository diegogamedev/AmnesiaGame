using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    public LevelSpinnerScript pipe;
    public int spinAmount;
    Vector3 eulerRotation;

    private void Awake()
    {
        eulerRotation = pipe.transform.eulerAngles;
    }

    public void RotatePipe()
    {
        eulerRotation.y += spinAmount;
        pipe.Spin(eulerRotation);
    }
}
