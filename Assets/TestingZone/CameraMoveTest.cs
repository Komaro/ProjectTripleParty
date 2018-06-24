using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.TestingZone;

public class CameraMoveTest : MonoBehaviour {
    
    int speed = 10;
    public Camera camera;
    
    public float timeScale;
    public float StartTime;
    public float second;


    void Awake()
    {
        timeScale = 1f;
        StartTime = Time.realtimeSinceStartup;
    }
    
    private void LateUpdate()
    {
        cameraZoom();
    }

    // Update is called once per frame
    void Update ()
    {
        second = Time.realtimeSinceStartup - StartTime;
        StartTime = Time.realtimeSinceStartup;
        
        cameraMove();
    }
    
    // Fix
    private void cameraMove()
    {
        float translation;
        float amtMove = speed * second * timeScale;

        if (Input.GetKey(KeyCode.A))
        {
            translation = -1;
            transform.Translate(translation * amtMove, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            translation = 1;
            transform.Translate(translation * amtMove, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            translation = 1;
            transform.Translate(0, translation * amtMove, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            translation = -1;
            transform.Translate(0, translation * amtMove, 0);
        }
    }

    // Missing
    private void _cameraMove()
    {
        //float amtMove = speed * Time.smoothDeltaTime * timeScale;
        float amtMove = speed * second * timeScale;

        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        Debug.Log(Input.GetAxis("Horizontal") + "  " + Input.GetAxis("Vertical"));

        transform.Translate(translationX * amtMove, 0, 0);
        transform.Translate(0, translationY * amtMove, 0);

    }

    private void cameraZoom()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize += 0.5f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && camera.orthographicSize > 1.0)
        {
            camera.orthographicSize -= 0.5f;
        }
    }
}
