using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlleyCommend : MonoBehaviour {

    public GameObject[] findEnemy;
    public float distance = 2.5f;
    public float dist;
    public float closestDistSqr;
    public Transform closestEnemy = null;

    public bool fireBatteryAvailable = false;
    public int fireBatteryCooltimeSec = 5;

    public LinkedList<GameObject> insideTarget;
    public GameObject selectTarget;
   
	// Use this for initialization
	void Start () {

        findEnemy = GameObject.FindGameObjectsWithTag("EnemyFleet");

        InvokeRepeating("serchEnemy", 0, 1.0f);
        InvokeRepeating("fireBattery", 0, 1.0f);
        InvokeRepeating("target", 0, 1.0f);

        StartCoroutine(fireBatteryCooltime());
       
	}
    
    // Update is called once per frame
    void Update () {

	}
    
    void serchEnemy()
    {
        //Debug.Log("serching_enamy...");
        closestDistSqr = Mathf.Infinity;

        foreach(GameObject serchingTarget in findEnemy)
        {
            Vector3 objectPos = serchingTarget.transform.position;
            dist = (objectPos - transform.position).sqrMagnitude;

            if (dist < 25f)
            {
                if (dist < closestDistSqr)
                {
                    closestDistSqr = dist;
                    closestEnemy = serchingTarget.transform;

                    if(insideTarget.Find(serchingTarget) == null)
                    {
                        insideTarget.AddLast(serchingTarget);
                    }
                }
            }
        }
    }
    
    void target()
    {
        foreach(GameObject target in insideTarget)
        {
            selectTarget = target;
        }
    }
    

    void fireBattery()
    {
        if (fireBatteryAvailable && (selectTarget != null))
        {
            //DestroyObject(closestEnemy);
            Debug.Log("destroy!");
            fireBatteryAvailable = false;
        }
    }

    // Not Work
    IEnumerator fireBatteryCooltime()
    {
        while(true)
        {
            if(fireBatteryCooltimeSec-- == 0)
            {
                Debug.Log("ready to fire");
                
                fireBatteryAvailable = true;
            }
            
            yield return new WaitForSeconds(1f);

            if (fireBatteryCooltimeSec <= 0 && !fireBatteryAvailable)
            {
                fireBatteryCooltimeSec = 5;
            }
        }
    }
}
