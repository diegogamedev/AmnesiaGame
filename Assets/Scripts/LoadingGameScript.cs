using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingGameScript : MonoBehaviour
{
    public Slider loadingBar;
    public Text loadingTxt;
    public int sceneToLoadIndex;
    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation loadscene = SceneManager.LoadSceneAsync(sceneToLoadIndex);

        while (!loadscene.isDone)
        {
            float progress = Mathf.Clamp01(loadscene.progress / .9f);
            loadingBar.value = progress;
            if(loadingTxt)
            {
                loadingTxt.text = (progress * 100).ToString() + "%";
            }
            yield return null;
        }
    }
}
