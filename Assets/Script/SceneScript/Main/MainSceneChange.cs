using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneChange : MonoBehaviour {

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
}