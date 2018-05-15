using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class directorySceneChange : MonoBehaviour {

    public void OnClick()
    {
        SceneManager.LoadScene("DirectoryScene");
    }
}