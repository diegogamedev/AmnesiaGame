using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    Animator animator;
    public GameObject panel;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(panelDisappear());
    }
    public void NextScene() 
    {
        panel.SetActive(true);
        animator.SetBool("StartGame", true);
        StartCoroutine(LoadNextScene());
    }

    IEnumerator panelDisappear()
    {
        yield return new WaitForSeconds(0.1f);
        panel.SetActive(false);
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(1);
    }
                

}
