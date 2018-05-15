using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.List;


public class DirectoryContentSize : MonoBehaviour {

    public GameObject directoryPrefabs;
    public GameObject newObject;

    private ScrollRect scrollRect;
    private int childCount;

	// Use this for initialization
	void Start () {

        directoryPrefabs = Resources.Load("Prefabs/DictionaryCharacterCard") as GameObject;
        scrollRect = GetComponent<ScrollRect>();
        
        addContentItem();
        setContentSize();
	}

	void addContentItem()
    {
        List<CharacterForm> characters =  CharacterList.getInstance().getCharacterList();

        foreach(CharacterForm character in characters)
        {
            newObject = MonoBehaviour.Instantiate(directoryPrefabs, scrollRect.content);
            newObject.name = "char_" + character.No;
            
            newObject.GetComponent<DirectoryObject>().Name.text = character.Name;
            newObject.GetComponent<DirectoryObject>().Image.sprite = character.Sprite;
        }

        //Testing Code
        //for (int i = 1; i < 61; i++)
        //{
        //    newObject = MonoBehaviour.Instantiate(directoryPrefabs, scrollRect.content);
        //    newObject.name = "item_" + i;
        //}
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
