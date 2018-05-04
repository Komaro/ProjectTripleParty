using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.SceneScript
{
    public class Fadeinout : MonoBehaviour
    {
        public float animTime = 2f;
        
        private float start;
        private float end;
        private float time;

        private Color color;
        private Image fadeImage;
        
        public void imageFadein(Image getImage) { StartCoroutine(fadeIn(getImage)); }
        public void imageFadeout(Image getImage) { StartCoroutine(fadeOut(getImage)); }

        IEnumerator fadeIn(Image getImage)
        {
            fadeImage = getImage;

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
        }
        IEnumerator fadeOut(Image getImage)
        {
            fadeImage = getImage;
            
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
}
