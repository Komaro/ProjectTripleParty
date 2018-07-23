using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSlotButton : MonoBehaviour {

    public int No
    {
        get;
        set;
    }
    public bool Empty
    {
        get;
        set;
    }
    
    
    public void ShipSlotButtonOnClick()
    {
        if (!Empty)
        {
            GameObject.Find("CharacterImage").GetComponent<Image>().sprite = CharacterList.getInstance().getCharacterFullImage(No);
        }
    } // View slot ship information
}