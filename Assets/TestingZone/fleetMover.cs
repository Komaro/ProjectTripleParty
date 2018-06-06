using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleetMover : MonoBehaviour
{

    public float speed = 1f;
    public bool order = false;
    public Vector3 dest;
    
    //충돌 감지
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        order = false;
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("click");
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dest.z = -1;
            order = true;            
        }

        if(order)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            //Debug.Log(dest.x + " " + dest.y);
            Debug.DrawLine(dest, transform.position, Color.red);

            if (transform.position == dest) order = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            order = false;
        }
    }
}
