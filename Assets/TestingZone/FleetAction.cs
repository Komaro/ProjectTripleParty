using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.TestingZone;

public class FleetAction : MonoBehaviour
{
    // Fleet move parameter
    public float FleetSpeed;
    public bool order;
    public Vector3 dest;

    void Start()
    {
        // Initialization
        FleetSpeed = 100f;
        fleetSpeedSetting();
        
        order = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            dest = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dest.z = -1;
            order = true;
        }

        if (order)
        {
            transform.position = Vector3.MoveTowards(transform.position, dest, FleetSpeed * Time.deltaTime);
            //Debug.Log(dest.x + " " + dest.y);
            Debug.DrawLine(dest, transform.position, Color.red);

            if (transform.position == dest) order = false;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        order = false;
    }
    
    private void fleetSpeedSetting()
    {
        AlleyShipAction[] AlleyShipList = transform.GetComponentsInChildren<AlleyShipAction>();

        foreach (AlleyShipAction selectShip in AlleyShipList)
        {
            if (selectShip.speed < FleetSpeed)
            {
                FleetSpeed = selectShip.speed;
            }
        }
    }
}
