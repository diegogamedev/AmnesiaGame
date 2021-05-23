using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToMenuListener : MonoBehaviour
{
    [SerializeField] Text text;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        text.color = Color.Lerp(Color.clear, Color.white, Mathf.PingPong(Time.time, 1));
    }
}
