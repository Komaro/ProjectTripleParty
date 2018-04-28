using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title_fadeinout : MonoBehaviour {

    public float animTime = 2f;

    private Image fadeImage;

    private float start;
    private float end;
    private float time;
    
	// Use this for initialization
	void Start () {

        fadeImage = GetComponent<Image>();
        StartCoroutine(ImageFadeInOutLoop());
	}

    IEnumerator ImageFadeInOutLoop()
    {
        Color color = fadeImage.color;

        while (true)
        {
            start = 0f;
            end = 1f;
            time = 0f;
            color.a = Mathf.Lerp(start, end, time);

            while (color.a < 1f)
            {
                time += Time.deltaTime / animTime;
                color.a = Mathf.Lerp(start, end, time);
                fadeImage.color = color;

                yield return null;
            }

            start = 1f;
            end = 0f;
            time = 0f;
            color.a = Mathf.Lerp(start, end, time);
            
            while (color.a > 0f)
            {
                time += Time.deltaTime / animTime;
                color.a = Mathf.Lerp(start, end, time);
                fadeImage.color = color;

                yield return null;
            }
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
