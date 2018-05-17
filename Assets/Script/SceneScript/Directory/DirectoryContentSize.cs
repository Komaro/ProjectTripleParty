using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.List;
using Assets.Script.ObjectScript;

public class DirectoryContentSize : MonoBehaviour {

    public GameObject directoryPrefabs;
    public GameObject newObject;

    private ScrollRect scrollRect;
    private int childCount;

	// Use this for initialization
	void Start () {

        directoryPrefabs = Resources.Load("Prefabs/DictionaryCharacterCard") as GameObject;
        scrollRect = GetComponent<ScrollRect>();

        StartCoroutine(addContentItem_cor());
	}

    IEnumerator addContentItem_cor()
    {
        List<CharacterForm> characters = CharacterList.getInstance().getCharacterList();
        
        foreach (CharacterForm character in characters)
        {
            newObject = MonoBehaviour.Instantiate(directoryPrefabs, scrollRect.content);
            newObject.name = "char_" + character.No;

            newObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            newObject.GetComponent<DirectoryObject>().Name.text = character.Name;
            newObject.GetComponent<DirectoryObject>().Image.sprite = character.cutSprite;
            newObject.GetComponent<DirectoryObject>().getForm = character;

            newObject.AddComponent<objectScaleChanger>().scaleUpDown(newObject.GetComponent<Image>(), 0.2f, 1.1f, 1.0f, 0.7f, 0.8f);

            yield return new WaitForSeconds(0.1f);
        }

        setContentSize();
    }

    void setContentSize()
    {
        childCount = scrollRect.content.childCount;
        
        if (childCount != 0)
        {
            float contentHeight = ((childCount / 6) * 270);

            if (childCount % 6 > 0) contentHeight += 270;

            scrollRect.content.sizeDelta = new Vector2(1280, contentHeight);
        }
    }
}
