using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.SceneScript;
using UnityEngine.UI;

public class testFadeinout : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        GetComponent<Fadeinout>().imageFadeout(GetComponent<Image>());
	}
}
