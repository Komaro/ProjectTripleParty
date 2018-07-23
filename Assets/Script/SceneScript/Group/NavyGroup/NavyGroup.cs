using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavyGroup : MonoBehaviour {

    public GameObject fleetSlotPrefabs;

    public GameObject fleetObject;
    public GameObject[] slotObject;
    public GameObject statusObject;
    public List<List<int>> fleetFormation;

    public int selectSlot;

    private void Awake()
    {
        //initialization
        selectSlot = 1;
        
        // Fleet slot initialization
        fleetSlotPrefabs = Resources.Load("Prefabs/FleetSlot") as GameObject;

        fleetFormation = UserData.getInstance().getFleetFormation();

        for (int i = 1; i <= fleetFormation.Count; i++)
        {
            GameObject newObject = Button.Instantiate(fleetSlotPrefabs, fleetObject.transform);
            newObject.name = "FleetSlot_" + (i);
            newObject.GetComponentInChildren<Text>().text = (i) + " 함대";
            newObject.GetComponent<NavySlotButton>().setFleetNum(i);
        }

        setFleetMember(selectSlot);

        // Exit button initialization
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(ExitButtonOnClick);
    }

    public void setFleetMember(int fleetNum)
    {
        //Debug.Log(fleetNum);

        // Reset slotObject
        foreach(GameObject slot in slotObject)
        {
            Text[] shipSlotText = slot.GetComponentsInChildren<Text>();
            shipSlotText[0].text = "";
            shipSlotText[1].text = "";

            slot.GetComponentInChildren<Text>().text = "";
            slot.GetComponent<ShipSlotButton>().Empty = true;
        }
        
        // Input ship data
        int selectShipSlot = 1;

        foreach (int shipNo in fleetFormation[fleetNum - 1])
        {
            GameObject shipSlot = GameObject.Find("ShipSlot_" + selectShipSlot++);
            shipSlot.GetComponent<ShipSlotButton>().No = shipNo;
            shipSlot.GetComponent<ShipSlotButton>().Empty = false;

            Text[] shipSlotText = shipSlot.GetComponentsInChildren<Text>();
            shipSlotText[0].text = shipNo.ToString();
            shipSlotText[1].text = CharacterList.getInstance().getCharacterName(shipNo);
            
            //GameObject.Find("ShipSlot_" + selectShipSlot++).GetComponentInChildren<Text>().text = CharacterList.getInstance().getCharacterName(shipNo);
        }
    }

    public void ExitButtonOnClick()
    {
        if(UserData.getInstance().beforeScene != null)
        {
            SceneManager.LoadScene(UserData.getInstance().beforeScene);
        }
        else
        {
            SceneManager.LoadScene("GroupScene");
        }
    }
}
