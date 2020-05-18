using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{    
    /* Esse script deve ser colocado na MainCamera
     * Dentro do array cameraPos, você cola GameObjects Vazios
     * Para marcar as posições que a camera vai ficar
     * Para trocar a camera de lugar, basta trocar o numero em
     * "indexDaPosicaoParaMover"
     */

    public Transform[] cameraPos;
    public int indexDaPosicaoParaMover;
    public float velocidadeSmoothDamp = 0.3f;
    public float velocidadeRotacao = 40f;
    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, cameraPos[indexDaPosicaoParaMover].localPosition, ref velocity, velocidadeSmoothDamp);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, cameraPos[indexDaPosicaoParaMover].localRotation, velocidadeRotacao * Time.deltaTime);
    }
}
