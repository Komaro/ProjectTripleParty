using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Script.StartingWork.List;

public class DirectoryObject : MonoBehaviour, IPointerEnterHandler{

    public Image Image;
    public Text Name;
    public CharacterForm getForm;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject.Find("CharacterFullImage").GetComponent<Image>().sprite = getForm.fullSprite;
        GameObject.Find("CharacterName").GetComponent<Text>().text = getForm.Name;
        GameObject.Find("CharacterCountry").GetComponent<Text>().text = getForm.Country;
        GameObject.Find("CharacterNo").GetComponent<Text>().text = getForm.No.ToString();
    }
}
