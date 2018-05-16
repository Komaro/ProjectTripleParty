using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.TestingZone;

public class CreateFilterPanel : MonoBehaviour {

    public GameObject filterPrefabs;
    public GameObject filterPanel;
    public Button scrollRect;
    private bool filterOpen = false;

    private void Start()
    {
        filterPrefabs = Resources.Load("Prefabs/FilteringPanel") as GameObject;
        scrollRect = GetComponent<Button>();
    }

    public void createPanel()
    {
        if(filterOpen == false)
        {
            CreatePanel();
        }
    }

    private void CreatePanel()
    {
        filterPanel = MonoBehaviour.Instantiate(filterPrefabs, gameObject.transform);
        filterPanel.name = "Filter Paenl";
        
        filterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);

        GetComponent<Button>().enabled = false;

        filterOpen = true;
    }
}
