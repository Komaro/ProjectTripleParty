using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.ObjectScript;
using UnityEngine.SceneManagement;

public class ArmyButtonClick : MonoBehaviour {

    // Panel
    public GameObject panelPrefabs;
    public GameObject createPanel;

    public string selectArmy;

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
                    selectArmy = "Navy";
                    break;

                    //case "Land":

                    //    panelPrefabs = Resources.Load("Prefabs/GroupLand" + "MenuPanel") as GameObject;
                    //    selectArmy = "Land";
                    //    break;

                    //case "Air":

                    //    panelPrefabs = Resources.Load("Prefabs/GroupAir" + "MenuPanel") as GameObject;
                    //    selectArmy = "Air";
                    //    break;
            }

            createPanel = MonoBehaviour.Instantiate(panelPrefabs, transform);
            createPanel.name = "MenuPanel";
            
            createPanel.GetComponent<ObjectScaleChanger>().scaleRightAndBottomUp(createPanel.GetComponent<Image>(), 0f, 1f, 0.1f, 1f, 0.2f, 0.3f);
            createPanel.GetComponent<ArmyButtonMenuPanel>().CreateBarMoveAnimation();
            createPanel.GetComponentInChildren<Button>().onClick.AddListener(delegate() {
                SceneManager.LoadScene(selectArmy + "GroupScene");
            });


            GetComponent<Button>().enabled = false;
        }
    }
}
