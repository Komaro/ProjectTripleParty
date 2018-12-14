using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.List;
using Assets.Script.ObjectScript;

// Use DirectoryScene : CharacterList ScrollView
//
// #######
// NOT USE
// #######
//

public class DirectoryContentSize : MonoBehaviour {

    public GameObject directoryPrefabs;
    public GameObject newObject;

    private ScrollRect scrollRect;
    

	// Use this for initialization
	void Start () {

        directoryPrefabs = Resources.Load("Prefabs/DirectoryCharacterCard") as GameObject;
        scrollRect = GetComponent<ScrollRect>();

        //StartCoroutine(addContentItem());
	}

    IEnumerator addContentItem()
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

            newObject.AddComponent<ObjectScaleChanger>().scaleUpDown(newObject.GetComponent<Image>(), 0.2f, 1.1f, 1.0f, 0.7f, 0.8f);

            yield return new WaitForSeconds(0.05f);
        }

        setContentSize(newObject);
    }

    private int childCount;
    private int childHeight;
    private int fixLineCount = 5;
    private int fixContentWidth = 1280;

    void setContentSize(GameObject item)
    {
        childCount = scrollRect.content.childCount;
        childHeight = (int)item.transform.GetComponent<RectTransform>().rect.height;
        
        if (childCount != 0)
        {
            float contentHeight = ((childCount / fixLineCount) * childHeight);

            if (childCount % fixLineCount > 0) contentHeight += childHeight;

            scrollRect.content.sizeDelta = new Vector2(fixContentWidth, contentHeight + (10 * (childCount / fixLineCount))); // Add scpacing
        }
    } 
}
