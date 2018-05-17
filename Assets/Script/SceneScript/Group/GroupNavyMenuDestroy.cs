using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.ObjectScript;

public class GroupNavyMenuDestroy : MonoBehaviour {

    // Animation
    private GameObject getObject;
    private Vector3 destPosition;

    private void OnDestroy()
    {
        gameObject.transform.parent.GetComponent<Button>().enabled = true;
        BarMoveAnimation();
    }

    private void BarMoveAnimation()
    {
        getObject = GameObject.Find(gameObject.tag + "Button SillingBar");
        destPosition = new Vector3(getObject.transform.localPosition.x, -40);
        getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.15f);

        getObject = GameObject.Find(gameObject.tag + "Button BottomBar");
        destPosition.Set(getObject.transform.localPosition.x, 40, 0f);
        getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.15f);
    }
}
