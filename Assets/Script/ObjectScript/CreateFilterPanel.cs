using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script.ObjectScript
{
    public class CreateFilterPanel : MonoBehaviour
    {
        public GameObject filterPrefabs;
        public GameObject filterPanel;
        public bool closePanel;
        
        private void Start()
        {
            filterPrefabs = Resources.Load("Prefabs/FilteringPanel") as GameObject;
            closePanel = true;
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !closePanel)
            {
                if (ObjectDestroyManager.getInstance().outClickDestroy("Filter", GameObject.Find("Canvas").GetComponent<GraphicRaycaster>())
                     && GetComponent<Button>().enabled == false)
                {
                    Destroy(filterPanel);
                    GetComponent<Button>().enabled = true;
                    closePanel = true;
                }
            }
        }

        public void createPanel()
        {
            if (GetComponent<Button>().enabled)
            {
                CreatePanel();
            }
        }
        private void CreatePanel()
        {
            filterPanel = MonoBehaviour.Instantiate(filterPrefabs, gameObject.transform);
            filterPanel.name = "Filter Paenl";

            filterPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);

            filterPanel.AddComponent<ObjectScaleChanger>().scaleUpDown(filterPanel.GetComponent<Image>(), 0f, 1f, 1f, 0.15f, 0f);

            GetComponent<Button>().enabled = false;
            closePanel = false;
        }
    }
}