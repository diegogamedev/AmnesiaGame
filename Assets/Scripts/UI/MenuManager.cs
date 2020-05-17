using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Fase1");
    }
}
