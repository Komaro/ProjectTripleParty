using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.SceneScript;

public class objectScaleUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(upscale(GetComponent<Image>()));
        gameObject.AddComponent<Fadeinout>().imageFadein(GetComponent<Image>());
	}

    IEnumerator upscale(Image getImage)
    {
        Image upImage = getImage;
        float time = 0f;
        float animTime = 0.7f;

        float start = 0.2f;
        float end = 1.2f;
        
        Vector3 vector = new Vector3((float)0.1, (float)0.1);

        while(upImage.transform.localScale.x < 1.2)
        {
            time += Time.deltaTime / animTime;

            vector.x = Mathf.Lerp(start, end, time);
            vector.y = Mathf.Lerp(start, end, time);
                
            upImage.transform.localScale = vector;
            
            yield return null;
        }

        time = 0;
        start = 1.2f;
        end = 1.0f;
        animTime = 1.0f;

        while(upImage.transform.localScale.x > 1.0f)
        {
            time += Time.deltaTime / animTime;

            vector.x = Mathf.Lerp(start, end, time);
            vector.y = Mathf.Lerp(start, end, time);

            upImage.transform.localScale = vector;

            yield return null;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
