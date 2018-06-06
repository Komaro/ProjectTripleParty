using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyCommend : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("available " + collision.tag);
       
    }

    // Update is called once per frame
    void Update () {
	}
}
