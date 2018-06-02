using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTest : MonoBehaviour {

    int speed = 10;
    public Camera camera;

	// Use this for initialization
	void Start () {
	}

    private void LateUpdate()
    {
        cameraZoom();
    }

    // Update is called once per frame
    void Update () {

        cameraMove();
    }
    
    private void cameraMove()
    {
        float amtMove = speed * Time.smoothDeltaTime;

        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        transform.Translate(translationX * amtMove, 0, 0);
        transform.Translate(0, translationY * amtMove, 0);
    }

    private void cameraZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize += 0.5f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            camera.orthographicSize -= 0.5f;
        }
    }
}
