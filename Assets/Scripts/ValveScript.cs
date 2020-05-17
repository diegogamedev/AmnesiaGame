using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValveScript : MonoBehaviour
{
    public LevelSpinnerScript pipe;
    public static bool cursorOver;
    Renderer rend;
    public Material defaultMat, highlightedMat;
    public int spinAmount;
    Vector3 eulerRotation;

    private void Awake()
    {
        eulerRotation = pipe.transform.eulerAngles;
        rend = GetComponent<Renderer>();
        
    }

    private void Update()
    {
        if (cursorOver)
        {
            rend.material = highlightedMat;
        }
        else
        {
            rend.material = defaultMat;
        }
    }

    public void RotatePipe()
    {
        eulerRotation.y += spinAmount;
        pipe.Spin(eulerRotation);
    }
}
