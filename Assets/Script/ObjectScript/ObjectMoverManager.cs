using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.ObjectScript
{
    public class ObjectMoverManager : MonoBehaviour
    {
        public float animTime;

        private Vector3 start;
        private Vector3 end;
        private float time;

        private Vector3 vector;
        private bool coroutineContinue = true;

        public void ObjectMove(GameObject getObject, Vector3 dest, float moveTime)
        {
            StartCoroutine(_ObjectMove(getObject, dest, moveTime));
        }

        IEnumerator _ObjectMove(GameObject getObject, Vector3 dest, float moveTime)
        {
            animTime = moveTime;
            start = getObject.transform.localPosition;
            end = dest;
            time = 0f;

            vector = new Vector3(0f, 0f);
            
            while (!getObject.transform.localPosition.Equals(end))
            {
                Debug.Log(getObject.transform.localPosition.x + " " + getObject.transform.localPosition.y);

                time += Time.deltaTime / this.animTime;

                vector = Vector3.Lerp(start, end, time);

                getObject.transform.localPosition = vector;

                yield return null;
            }
        }
    }
}