using System.Collections;
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
    private List<GameObject> enemyList; // not GameObject => GameObject + distance value (objectDistance)

    public GameObject priorityTarget;
    public GameObject currentTarget;
    

	// Use this for initialization
	void Start () {

        // Temp initialization
        alleyRange = 25f;
        targetingTime = 5f;





        enemyList = new List<GameObject>();

        InvokeRepeating("SearchingEnemy", 0, 0.25f);
        InvokeRepeating("selectTarget", 0, targetingTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float targetDistance;

    void SearchingEnemy()
    {
        foreach(GameObject target in EnemyInformation.getInstance().getEnemyList())
        {
            targetDistance = (target.transform.position - transform.position).sqrMagnitude;

            if(targetDistance <= alleyRange && !enemyList.Contains(target))
            {
                Debug.Log("enemy add");
                enemyList.Add(target);
            }
            else if(targetDistance > alleyRange && enemyList.Contains(target))
            {
                Debug.Log("enemy delete");
                enemyList.Remove(target);
            }
        }
    }

    void selectTarget()
    {
        if (enemyList.Count == 0) return;

        if(priorityTarget == null)
        {
            // foareach() // Min distance enemy select
        }
    }

    void firingBattery()
    {

    }
}
