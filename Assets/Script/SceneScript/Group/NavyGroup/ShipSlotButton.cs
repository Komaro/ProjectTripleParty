using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSlotButton : MonoBehaviour {

    public int slotNum;

    public int ShipNo;
    public bool Empty;
    public GameObject NavyGroup;
    
    public void ShipSlotButtonOnClick()
    {
        if (!Empty)
        {
            GameObject.Find("CharacterImage").GetComponent<Image>().sprite = CharacterList.getInstance().getCharacterFullImage(ShipNo);
        }

        NavyGroup.GetComponent<NavyGroup>().selectMemberSlot = ShipNo;
    } // View slot ship information
}