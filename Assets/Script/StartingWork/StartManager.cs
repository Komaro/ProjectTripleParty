using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.SceneScript;

public class StartManager : MonoBehaviour {
    
	void Start () {

        gameObject.AddComponent<Fadeinout>();
    }
}
