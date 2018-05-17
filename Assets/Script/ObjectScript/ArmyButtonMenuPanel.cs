using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class ArmyButtonMenuPanel : MonoBehaviour
    {
        GameObject panelPrefabs;
        GameObject createPanel;

        public void NavyButtonClick(GameObject parentObject) {

            if (GetComponent<Button>().enabled == true)
            {
                Destroy(GameObject.Find("MenuPanel"));
                createPanel = null;
                NavyButtonPanelCreate(parentObject);
            }
        }
        
        private void NavyButtonPanelCreate(GameObject parentObject)
        {
            panelPrefabs = Resources.Load("Prefabs/GoupNavyMenuPanel") as GameObject;
            
            createPanel = MonoBehaviour.Instantiate(panelPrefabs, parentObject.transform);
            createPanel.name = "MenuPanel";

            createPanel.AddComponent<objectScaleChanger>().scaleRightAndBottomUp(createPanel.GetComponent<Image>(), 0f, 1f, 0.1f, 1f, 0.5f, 0.3f);
            
            GetComponent<Button>().enabled = false;
        }
    }
}