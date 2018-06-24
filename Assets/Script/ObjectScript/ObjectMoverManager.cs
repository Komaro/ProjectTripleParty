using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.ObjectScript
{
    public class ObjectMoverManager : MonoBehaviour
    {
        public float animTime;
        public Vector3 start;
        public Vector3 end;
        public float time;
        
        public void ObjectMove(GameObject getObject, Vector3 dest, float moveTime)
        {
            StartCoroutine(_ObjectMove(getObject, dest, moveTime));
        }
        public void ObjectRotation_180(GameObject getObject, float rotationAngle)
        {
            StartCoroutine(_ObjectRotation_180(getObject,rotationAngle));
        }
        
        IEnumerator _ObjectMove(GameObject getObject, Vector3 dest, float moveTime)
        {
            animTime = moveTime;
            start = getObject.transform.localPosition;
            end = dest;
            time = 0f;

            Vector3 vector = new Vector3(0f, 0f);
            
            while (!getObject.transform.localPosition.Equals(end))
            {
                //Debug.Log(getObject.transform.localPosition.x + " " + getObject.transform.localPosition.y);

                time += Time.deltaTime / animTime;

                vector = Vector3.Lerp(start, end, time);

                getObject.transform.localPosition = vector;

                yield return null;
            }
        }
        
        // Warning // RotationAngle is only 180 factor
        IEnumerator _ObjectRotation_180(GameObject getObject, float RotationAngle)
        {
            float rotationCount = 180 / RotationAngle;

            for(float i = 0; i  < rotationCount; i++)
            {
                getObject.transform.Rotate(0, 0, 10);

                yield return new WaitForFixedUpdate();
            }
        }
    }
}