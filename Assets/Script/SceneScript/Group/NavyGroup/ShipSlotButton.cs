using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipSlotButton : MonoBehaviour {
    
    public int No;
    
    private void OnMouseOver()
    {
        
    } // View character status

    private void ShipSlotButtonOnClick()
    {
        UserData.getInstance().beforeScene = "NavyGroupScene";

        SceneManager.LoadScene("NavyGroupSelectScene");
    } // Open ship select directory
}
