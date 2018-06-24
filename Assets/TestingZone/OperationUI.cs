using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationUI : MonoBehaviour {

    bool pause;

    GameObject pauseText;
    
    void Awake()
    {
        pause = false;

        pauseText = GameObject.Find("PasueText").gameObject;
        pauseText.SetActive(false);
    }
    
	void Start () {

        
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && !pause)
        {
            Time.timeScale = 0f;
            pauseText.SetActive(true);
            pause = true;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && pause)
        {
            Time.timeScale = 1f;
            pauseText.SetActive(false);
            pause = false;
        }
    }
}
