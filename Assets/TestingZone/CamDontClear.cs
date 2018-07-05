using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamDontClear : MonoBehaviour {

    [SerializeField]
    private Camera camera;

    void Awake()
    {
        if(camera == null)
        {
            camera = GetComponent<Camera>();

            Initalize();
        }
    }

    public void Initalize()
    {
        camera.clearFlags = CameraClearFlags.Color;
    }

    private void OnPostRender()
    {
        camera.clearFlags = CameraClearFlags.Nothing;
    }
}
