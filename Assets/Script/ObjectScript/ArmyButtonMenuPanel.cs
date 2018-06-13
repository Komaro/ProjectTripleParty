using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class ArmyButtonMenuPanel : MonoBehaviour
    {
        // Panel
        GameObject panelPrefabs;
        GameObject createPanel;

        // Animation
        private GameObject getObject;
        private Vector3 destPosition;
        
        public void ArmyButtonClick(GameObject parentObject)
        {
            if (GetComponent<Button>().enabled == true)
            {
                Destroy(GameObject.Find("MenuPanel"));
                createPanel = null;

                switch (parentObject.tag)
                {
                    case "Navy":

                        ButtonPanelCreate(parentObject, "Navy");
                        break;

                    case "Land":

                        ButtonPanelCreate(parentObject, "Land");
                        break;

                    case "Air":

                        ButtonPanelCreate(parentObject, "Air");
                        break;
                }
            }
        }
        
        /*
        public void NavyButtonClick(GameObject parentObject) {

            if (GetComponent<Button>().enabled == true)
            {
                Destroy(GameObject.Find("MenuPanel"));
                createPanel = null;
                NavyButtonPanelCreate(parentObject);
            }
        }
        public void LandButtonClick(GameObject parentObject)
        {
            if (GetComponent<Button>().enabled == true)
            {
                Destroy(GameObject.Find("MenuPanel"));
                createPanel = null;
                LandButtonPanelCreate(parentObject);
            }
        }
        public void AirButtonClick(GameObject parentObject)
        {
            if (GetComponent<Button>().enabled == true)
            {
                Destroy(GameObject.Find("MenuPanel"));
                createPanel = null;
                AirButtonPanelCreate(parentObject);
            }
        }
        */

        private void ButtonPanelCreate(GameObject parentObject, string army)
        {
            panelPrefabs = Resources.Load("Prefabs/Goup" + army + "MenuPanel") as GameObject;
            
            createPanel = MonoBehaviour.Instantiate(panelPrefabs, parentObject.transform);
            createPanel.name = "MenuPanel";

            createPanel.AddComponent<ObjectScaleChanger>().scaleRightAndBottomUp(createPanel.GetComponent<Image>(), 0f, 1f, 0.1f, 1f, 0.2f, 0.3f);
            
            GetComponent<Button>().enabled = false;

            BarMoveAnimation();
        }

        private void BarMoveAnimation()
        {
            getObject = GameObject.Find(gameObject.tag + "Button SillingBar");
            destPosition = new Vector3(getObject.transform.localPosition.x, 330);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.5f);

            getObject = GameObject.Find(gameObject.tag + "Button BottomBar");
            destPosition.Set(getObject.transform.localPosition.x, -330, 0f);
            getObject.GetComponent<ObjectMoverManager>().ObjectMove(getObject, destPosition, 0.5f);
        }
    }
}