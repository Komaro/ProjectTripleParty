using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleLineScript : MonoBehaviour {

    public float thetaInterval = .1f; // 각도 단위.
    public float rad = 1f; // 반지름 unit
    LineRenderer lr;
    

    // Use this for initialization
    void Start () {
        
        lr = GetComponent<LineRenderer>();

        CreatePoints();
    }
    
    void CreatePoints()
    {

        int index = 0;
        Vector3 firstPoint = Vector3.zero;
        lr.SetVertexCount((int)(2 * Mathf.PI / thetaInterval) + 2); // 정점 갯수 설정

        for (float theta = 0f; theta < (2 * Mathf.PI); theta += thetaInterval)
        {
            float x = (rad * 2.5f) * Mathf.Cos(theta); //현재각도에-> 원의좌표로 변환
            float y = (rad * 2.5f) * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 1);

            lr.SetPosition(index, pos);

            if (index == 0) firstPoint = pos;
            index++;
        }

        lr.SetPosition(index, firstPoint);
    }
}
