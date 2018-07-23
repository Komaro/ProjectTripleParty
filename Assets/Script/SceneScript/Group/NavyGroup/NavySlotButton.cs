using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavySlotButton : MonoBehaviour {

    public int fleetNum;
    
    public void setFleetNum(int fleetNum)
    {
        this.fleetNum = fleetNum;
    }

    public void NavySlotButtonOnClick()
    {
        
        GameObject.Find("NavyGroupScript").GetComponent<NavyGroup>().SendMessage("setFleetMember", fleetNum);
    }
}
