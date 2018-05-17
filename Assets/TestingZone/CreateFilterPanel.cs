using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Assets.Script.ObjectScript;

public class CreateFilterPanel : MonoBehaviour {

    public GameObject filterPrefabs;
    public GameObject filterPanel;
    public Button scrollRect;

    private void Start()
    {
        filterPrefabs = Resources.Load("Prefabs/FilteringPanel") as GameObject;
        scrollRect = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key was pressed.");
            GetComponent<Button>().enabled = true;
            Destroy(filterPanel);
            filterPanel = null;
        }
    }

    public void createPanel()
    {
        if(GetComponent<Button>().enabled == true)
        {
            CreatePanel();
        }
    }

    private void CreatePanel()
    {
        filterPanel = MonoBehaviour.Instantiate(filterPrefabs, gameObject.transform);
        filterPanel.name = "Filter Paenl";
        
        filterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
        filterPanel.AddComponent<objectScaleChanger>().scaleUpDown(filterPanel.GetComponent<Image>(), 0f, 1f, 1f, 0.15f, 0f);

        GetComponent<Button>().enabled = false;
    }
}
