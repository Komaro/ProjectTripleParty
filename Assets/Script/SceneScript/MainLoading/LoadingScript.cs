using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.SceneScript;

public class LoadingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<loadingManager>();

        GetComponent<loadingManager>().sceneLoad(GetComponent<Image>(), "MainScene");
    }
}
