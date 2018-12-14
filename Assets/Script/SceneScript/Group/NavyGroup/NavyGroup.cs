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

    public int selectFleetSlot;
    public int selectMemberSlot;

    private void Awake() 
    {
        //initialization
        selectFleetSlot = 1;
        selectMemberSlot = 0;
        
        // Fleet slot initialization
        fleetSlotPrefabs = Resources.Load("Prefabs/FleetSlot") as GameObject;

        fleetFormation = UserData.getInstance().getFleetFormation();

        for (int i = 1; i <= fleetFormation.Count; i++)
        {
            addFleet(i);
        }

        setFleetMember(selectFleetSlot);

        // Exit button initialization
        
        GameObject.Find("AddFleetButton").GetComponent<Button>().onClick.AddListener(AddFleetButtonOnClick);
        GameObject.Find("SelectShipButton").GetComponent<Button>().onClick.AddListener(SelectShipButtonOnClick);
        GameObject.Find("DisbandFleetButton").GetComponent<Button>().onClick.AddListener(DisbendFleetButtonOnClick);
        GameObject.Find("ExitButton").GetComponent<Button>().onClick.AddListener(ExitButtonOnClick);
    }

    public void addFleet(int fleetNum)
    {
        GameObject newObject = Button.Instantiate(fleetSlotPrefabs, fleetObject.transform);
        newObject.name = "FleetSlot_" + (fleetNum);
        newObject.GetComponentInChildren<Text>().text = (fleetNum) + " 함대";
        newObject.GetComponent<NavySlotButton>().setFleetNum(fleetNum);
    } // Add fleet slot to FleetObject

    public void setFleetMember(int fleetNum)
    {
        //Debug.Log(fleetNum);

        // Reset slotObject
        selectFleetSlot = fleetNum;
        resetFleetMember();
        
        // Input ship data
        int selectShipSlot = 1;

        foreach (int shipNo in fleetFormation[fleetNum - 1])
        {
            GameObject shipSlot = GameObject.Find("ShipSlot_" + selectShipSlot++);
            shipSlot.GetComponent<ShipSlotButton>().ShipNo = shipNo;
            shipSlot.GetComponent<ShipSlotButton>().Empty = false;

            Text[] shipSlotText = shipSlot.GetComponentsInChildren<Text>();
            shipSlotText[0].text = shipNo.ToString();
            shipSlotText[1].text = CharacterList.getInstance().getCharacterName(shipNo);
            
            //GameObject.Find("ShipSlot_" + selectShipSlot++).GetComponentInChildren<Text>().text = CharacterList.getInstance().getCharacterName(shipNo);
        }
    } // Set fleet member
    public void resetFleetMember()
    {
        foreach (GameObject slot in slotObject)
        {
            Text[] shipSlotText = slot.GetComponentsInChildren<Text>();
            shipSlotText[0].text = "";
            shipSlotText[1].text = "";
            
            slot.GetComponentInChildren<Text>().text = "";
            slot.GetComponent<ShipSlotButton>().Empty = true;
        }
    } // Reset fleet member
 
    public void AddFleetButtonOnClick()
    {
        Debug.Log("TEST ADD FLEET BUTTON ON CLICK");

        if (fleetFormation.Count < 5)
        {
            addFleet(fleetFormation.Count + 1);
            fleetFormation.Add(new List<int>());
        }
    }
    public void SelectShipButtonOnClick()
    {
        if (selectMemberSlot != 0)
        {
            Debug.Log("SELECT MEMBER SLOT");

            UserData.getInstance().selectGroup = (int)Properties.Group.Navy;
            SceneManager.LoadScene("DirectoryScene");
        }
        else
        {
            Debug.Log("NOT SELECT MEMBER SLOT");
        }
    }
    public void DisbendFleetButtonOnClick()
    {
        Debug.Log("TEST DISBEND FLEET BUTTON ON CLICK");

        fleetFormation.RemoveAt(selectFleetSlot - 1);

        Destroy(GameObject.Find("FleetSlot_" + selectFleetSlot));
        resetFleetMember();
    }
    public void ExitButtonOnClick()
    {
        if (UserData.getInstance().beforeScene != null)
        {
            SceneManager.LoadScene(UserData.getInstance().beforeScene);
        }
        else
        {
            SceneManager.LoadScene("GroupScene");
        }
    }
}
