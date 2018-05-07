using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingManager : MonoBehaviour {

    private Image progressBar;

	// Use this for initialization
	void Start () {
		
	}
    
    public void sceneLoad(Image inputImage, string sceneName) { StartCoroutine(loadScene(inputImage, sceneName)); }
    
    IEnumerator loadScene(Image inputImage, string sceneName)
    {
        yield return null;

        progressBar = inputImage;
        AsyncOperation loadingOper = SceneManager.LoadSceneAsync("MainScene");
        loadingOper.allowSceneActivation = false;

        float timer = 0.0f;

        while(!loadingOper.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if(loadingOper.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);

                if (progressBar.fillAmount == 1.0f) loadingOper.allowSceneActivation = true;
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, loadingOper.progress, timer);
                
                if(progressBar.fillAmount >= loadingOper.progress)
                {
                    timer = 0f;
                }
             
            }
        }
    }
}
