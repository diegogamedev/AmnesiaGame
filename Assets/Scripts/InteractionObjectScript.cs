using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectScript : MonoBehaviour
{
    public LevelSpinnerScript spin;
    public Vector3 eulerSpinTo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spin.Spin(eulerSpinTo);
        }

    }
}
