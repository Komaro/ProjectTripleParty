using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.ObjectScript;

public class ArmyButtonClick : MonoBehaviour {

    // Panel
    public GameObject panelPrefabs;
    public GameObject createPanel;

    public void onClick()
    {
        if (GetComponent<Button>().enabled)
        {
            Destroy(GameObject.Find("MenuPanel"));
            createPanel = null;

            switch (gameObject.tag)
            {
                case "Navy":

                    panelPrefabs = Resources.Load("Prefabs/GroupNavy" + "MenuPanel") as GameObject;
                    break;

                //case "Land":

                //    panelPrefabs = Resources.Load("Prefabs/GroupLand" + "MenuPanel") as GameObject;
                //    break;

                //case "Air":

                //    panelPrefabs = Resources.Load("Prefabs/GroupAir" + "MenuPanel") as GameObject;
                //    break;
            }

            createPanel = MonoBehaviour.Instantiate(panelPrefabs, transform);
            createPanel.name = "MenuPanel";
            
            createPanel.GetComponent<ObjectScaleChanger>().scaleRightAndBottomUp(createPanel.GetComponent<Image>(), 0f, 1f, 0.1f, 1f, 0.2f, 0.3f);
            createPanel.GetComponent<ArmyButtonMenuPanel>().CreateBarMoveAnimation();

            GetComponent<Button>().enabled = false;
        }
    }
}
