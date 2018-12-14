using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.List;
using Assets.Script.ObjectScript;

public class DirectroyScene : MonoBehaviour {

    // Content
    public GameObject directoryPrefabs;
    public GameObject newObject;

    public GameObject CharacterListScrollView;
    
    // Select
    public int enterGroup;

    // Use this for initialization
    private void Awake()
    {
        directoryPrefabs = Resources.Load("Prefabs/DirectoryCharacterCard") as GameObject;

        checkGroup();

        StartCoroutine(addContentItem());
    }

    IEnumerator addContentItem()
    {
        
        List<CharacterForm> characters = CharacterList.getInstance().getCharacterList();

        foreach (CharacterForm character in characters)
        {
            newObject = MonoBehaviour.Instantiate(directoryPrefabs, CharacterListScrollView.GetComponent<ScrollRect>().content);
            newObject.name = "char_" + character.No;

            newObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            newObject.GetComponent<DirectoryObject>().Name.text = character.Name;
            newObject.GetComponent<DirectoryObject>().Image.sprite = character.cutSprite;
            newObject.GetComponent<DirectoryObject>().getForm = character;

            newObject.AddComponent<ObjectScaleChanger>().scaleUpDown(newObject.GetComponent<Image>(), 0.2f, 1.1f, 1.0f, 0.6f, 0.7f);

            yield return new WaitForSeconds(0.05f);
        }

        setContentSize(newObject);
    }

    private int childCount;
    private int childHeight;
    private int fixLineCount = Properties.fixLineCount;
    private int fixContentWidth = Properties.fixContentWidth;

    public void setContentSize(GameObject item)
    {
        childCount = CharacterListScrollView.GetComponent<ScrollRect>().content.childCount;
        childHeight = (int)item.transform.GetComponent<RectTransform>().rect.height;

        if (childCount != 0)
        {
            float contentHeight = ((childCount / fixLineCount) * childHeight);

            if (childCount % fixLineCount > 0) contentHeight += childHeight;

            CharacterListScrollView.GetComponent<ScrollRect>().content.sizeDelta = new Vector2(fixContentWidth, contentHeight + (10 * (childCount / fixLineCount))); // Add scpacing
        }
    }
    public void checkGroup()
    {
        switch(UserData.getInstance().selectGroup)
        {
            case (int)Properties.Group.Navy:
                enterGroup = (int)Properties.Group.Navy;
                break;
            case (int)Properties.Group.Land:
                enterGroup = (int)Properties.Group.Land;
                break;
            case (int)Properties.Group.Air:
                enterGroup = (int)Properties.Group.Air;
                break;
        }
    }
}
