using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObjectScript : MonoBehaviour
{
    public LevelSpinnerScript spin;
    public Vector3 eulerSpinTo;
    AudioSource memoryAudio;
    public AudioSource memory;

    /*
     * Quando o player entra no trigger, ele chama o
     * E insire a variavel eulerSpinTo, 
     * que carrega uma coordenada global do giro,
     * na função Spin(), na classe LevelSpinnerScript.cs
     */
    private void Awake()
    {
        memoryAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spin.Spin(eulerSpinTo);
            memory.Play();
            memoryAudio.Play();
            StartCoroutine(FadeAudio(memoryAudio.clip.length, 0.1f));
        }
    }

    IEnumerator FadeAudio(float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = memoryAudio.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            memoryAudio.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
