using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Script.ObjectScript;

public class MainSceneButton : MonoBehaviour {
    
    void Start()
    {
        gameObject.AddComponent<ObjectMoverManager>();

        InvokeRepeating("runRotation", Random.Range(0f, 20f), 10f);
    }

    

    
    public void OnClick()
    {
        switch(gameObject.name)
        {
            case "DirectoryButton":

                SceneManager.LoadScene("DirectoryScene");
                break;

            case "GroupButton":

                SceneManager.LoadScene("GroupScene");
                break;
        }

    }

    private void runRotation()
    {
        GetComponent<ObjectMoverManager>().ObjectRotation_180(gameObject, 5f);
    }
}