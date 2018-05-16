using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class objectScaleChanger : MonoBehaviour
    {
        public float animTime = 0f;

        private float time = 0f;
        private float start = 0f;
        private float end = 0f;

        private Image upImage;
        private Vector3 vector;

        public void scaleupdown(Image getImage, float upStart, float upEnd, float downEnd, float upTime, float downTime){
            StartCoroutine(scaleUpAndDown(getImage, upStart, upEnd, downEnd, upTime, downTime));
        }

        IEnumerator scaleUpAndDown(Image getImage, float upStart, float upEnd, float downEnd, float upTime, float downTime)
        {
            Image upImage = getImage;
            time = 0f;
            animTime = upTime;

            start = upStart;
            end = upEnd;

            vector = new Vector3((float)0.1, (float)0.1);

            while (upImage.transform.localScale.x < upEnd)
            {
                time += Time.deltaTime / this.animTime;

                vector.x = Mathf.Lerp(start, end, time);
                vector.y = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }

            time = 0f;
            start = upEnd;
            end = downEnd;
            animTime = downTime;

            while (upImage.transform.localScale.x > downEnd)
            {
                time += Time.deltaTime / this.animTime;

                vector.x = Mathf.Lerp(start, end, time);
                vector.y = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }
        }

    }
}