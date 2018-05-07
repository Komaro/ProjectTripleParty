using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.SceneScript;

public class fadeinoutBase : MonoBehaviour {
    
	void Start () {
        //default
        gameObject.AddComponent<Fadeinout>().imageFadein(GetComponent<Image>());
	}
	
}
