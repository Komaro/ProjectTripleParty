using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class ObjectScaleChanger : MonoBehaviour
    {
        public float animTime = 0f;

        private float time = 0f;
        private float start = 0f;
        private float end = 0f;

        private Image upImage;
        private Vector3 vector;

        public void scaleUpDown(Image getImage, float upStart, float upEnd, float downEnd, float upTime, float downTime){
            StartCoroutine(scaleUpAndDownImage(getImage, upStart, upEnd, downEnd, upTime, downTime));
        }
        public void scaleRightAndBottomUp(Image getImage, float rightStart, float rightEnd, float downStart, float downEnd, float rightTime, float downTime) {
            StartCoroutine(scaleRightAndBottomUpImage(getImage, rightStart, rightEnd, downStart, downEnd, rightTime, downTime));
        }

        IEnumerator scaleUpAndDownImage(Image getImage, float upStart, float upEnd, float downEnd, float upTime, float downTime)
        {
            upImage = getImage;
            resetParameter(upTime, upStart, upEnd);
            
            vector = new Vector3((float)0, (float)0);

            while (upImage.transform.localScale.x < upEnd)
            {
                time += Time.deltaTime / this.animTime;
                vector.x = Mathf.Lerp(start, end, time);
                vector.y = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }

            resetParameter(downTime, upEnd, downEnd);
            
            while (upImage.transform.localScale.x > downEnd)
            {
                time += Time.deltaTime / this.animTime;
                vector.x = Mathf.Lerp(start, end, time);
                vector.y = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }
        }
        IEnumerator scaleRightAndBottomUpImage(Image getImage, float rightStart, float rightEnd, float downStart, float downEnd, float rightTime, float downTime)
        {
            upImage = getImage;

            resetParameter(rightTime, rightStart, rightEnd);
            vector.y = downStart;

            while(upImage.transform.localScale.x < rightEnd)
            {
                time += Time.deltaTime / this.animTime;
                vector.x = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }

            resetParameter(downTime, downStart, downEnd);

            while (upImage.transform.localScale.y < downEnd)
            {
                time += Time.deltaTime / this.animTime;
                vector.y = Mathf.Lerp(start, end, time);

                upImage.transform.localScale = vector;

                yield return null;
            }
        }

        private void resetParameter(float time, float start, float end)
        {
            this.time = 0f;
            animTime = time;
            this.start = start;
            this.end = end;
        }
    }
}