﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.TestingZone;

public class AlleyFleetAction : MonoBehaviour {

    // Alley Base Status
    public float alleyRange;
    public float targetingTime;

    // Alley Move Status
    public float speed;
    public bool moveOrder = false;
    public Vector3 moveDest;

    // Alley Searching And Targeting Parameter
    //private List<GameObject> enemyList; // not GameObject => GameObject + distance value (objectDistance)
    private List<TargetingList> enemyList;

    public GameObject priorityTarget;
    public GameObject currentTarget;

    void Start()
    {
        // Temp initialization
        alleyRange = 25f;
        targetingTime = 5f;

        enemyList = new List<TargetingList>();

        InvokeRepeating("enemyDistanceCalc", 0, 1f);
        InvokeRepeating("selectTarget", 0, targetingTime);
    }

    // Enemy Searching
    private void OnTriggerEnter2D(Collider2D col)
    {
        TargetingList enterTarget;

        if (col.tag.Equals("EnemyFleet") && CheckingEnemyList(col.gameObject))
        {
            Debug.Log("Enter Enemy");

            enterTarget = new TargetingList(col.gameObject);
            enemyDistanceCalc(enterTarget);
            enemyList.Add(enterTarget);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (currentTarget == col.gameObject) currentTarget = null;
        if (priorityTarget == col.gameObject) priorityTarget = null;

        Debug.Log("Exit Enemy");
        
        enemyList.Remove(CheckingExitList(col.gameObject));
    }

    // Check Target List
    private bool CheckingEnemyList(GameObject other)
    {
        foreach(TargetingList select in enemyList)
        {
            if (select.Object == other) return false;
        }

        return true;
    }
    private TargetingList CheckingExitList(GameObject other)
    {
        foreach (TargetingList select in enemyList)
        {
            if (select.Object == other) return select;
        }

        return null;
    }

    // Calc enemyList distance
    private void enemyDistanceCalc()
    {
        if (enemyList.Count == 0) return;

        foreach (TargetingList target in enemyList)
        {
            target.Distance = (target.Object.transform.position - transform.position).sqrMagnitude;
            Debug.Log(target.Object.name + " " + target.Distance);
        }
    }
    private void enemyDistanceCalc(TargetingList enemy)
    {
        enemy.Distance = (enemy.Object.transform.position - transform.position).sqrMagnitude;
    }
    
    // Target Select (Min or Priority)
    private void selectTarget()
    {
        if (enemyList.Count == 0) return;
        
        if(priorityTarget == null && currentTarget == null)
        {
            currentTarget = minDistanceTarget().Object;
        }
        else if(priorityTarget != null)
        {
            currentTarget = priorityTarget;
        }
    }
    public TargetingList minTarget = new TargetingList(9999999f);
    private TargetingList minDistanceTarget()
    { 
        foreach(TargetingList target in enemyList)
        {
            if (minTarget.Distance > target.Distance) minTarget = target;
        }

        return minTarget;
    }

    // Firing Wapeon
    void firingBattery()
    {

    }
}
