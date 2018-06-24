using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class ArmyButtonMenuPanel : MonoBehaviour
    {
        // Animation
        public GameObject getObject;
        public Vector3 destPosition;
        
        private void OnDestroy()
        {
            gameObject.transform.parent.GetComponent<Button>().enabled = true;
            DestroyBarMoveAnimation();
        }

        public void CreateBarMoveAnimation()
        {
            getObject = GameObject.Find(gameObject.tag + "Button SillingBar");
            destPosition = new Vector3(getObject.transform.localPosition.x, 330);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.5f);

            getObject = GameObject.Find(gameObject.tag + "Button BottomBar");
            destPosition.Set(getObject.transform.localPosition.x, -330, 0f);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.5f);
        }

        public void DestroyBarMoveAnimation()
        {
            getObject = GameObject.Find(gameObject.tag + "Button SillingBar");
            destPosition = new Vector3(getObject.transform.localPosition.x, -40);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.15f);

            getObject = GameObject.Find(gameObject.tag + "Button BottomBar");
            destPosition.Set(getObject.transform.localPosition.x, 40, 0f);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.15f);
        }
    }
    
}