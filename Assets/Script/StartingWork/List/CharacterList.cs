using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Assets.Script.StartingWork.List;
using System.Data;
using System.IO;

public class CharacterList{

    private static CharacterList instance;

    private List<CharacterForm> Characters = new List<CharacterForm>();
    private CharacterForm[] connectCharacters;

    private List<CharacterForm> filteringCharacters = new List<CharacterForm>();
    

    public CharacterList()
    {
        createCharacterList();
    }

    public static CharacterList getInstance()
    {
        if(instance == null)
        {
            instance = new CharacterList();
        }

        return instance;
    }
    
    public List<CharacterForm> getCharacterList()
    {
        return Characters;
    } // All character
    public List<CharacterForm> getCharacterList(int nofilter)
    {
        filteringCharacters.Clear();

        foreach (CharacterForm readForm in Characters)
        {
            if (readForm.No == nofilter) { filteringCharacters.Add(readForm); }
        }

        return filteringCharacters;
    } // Character no(number) filtering
    public List<CharacterForm> getCharacterList(string countryFilter)
    {
        filteringCharacters.Clear();

        foreach (CharacterForm readForm in Characters)
        {
            if (readForm.Country == countryFilter) { filteringCharacters.Add(readForm); }
        }

        return filteringCharacters;
    } // Character country filtering

    public string getCharacterName(int no)
    {
        return connectCharacters[no - 1].Name;
    }// Character name return
    public Sprite getCharacterFullImage(int no)
    {
        return connectCharacters[no - 1].fullSprite;
    } // Character full image return
    
    private void createCharacterList()
    {
        List<Dictionary<string, object>> characterList = CSVManager.Read("Character/CharacterList");

        connectCharacters = new CharacterForm[characterList.Count];
        
        for(int i = 0; i < characterList.Count; i++)
        {
            CharacterForm createCharacterForm = new CharacterForm((int)characterList[i]["no"],
                                             characterList[i]["name"].ToString(),
                                             (int)characterList[i]["image"],
                                             switchCountry((int)characterList[i]["country"]),
                                             switchGroup((int)characterList[i]["group"]));

            Characters.Add(createCharacterForm);

            connectCharacters[i] = createCharacterForm;
        }
    }// Read character data(csv)

    private enum Faction {USA = 1, KGM, HMS, IJN}
    private string switchCountry(int countryNo)
    {
        string country = null;

        switch(countryNo)
        {
            case (int)Faction.USA:

                country = "USA";
                break;

            case (int)Faction.KGM:

                country = "미정";
                break;

            case (int)Faction.HMS:

                country = "영국";
                break;

            case (int)Faction.IJN:

                country = "미정";
                break;

            default:

                country = "미정";
                break;
        }

        return country;
    } // Convert code to country name

    private enum Group {Navy, Land, Air}
    private string switchGroup(int groupNo)
    {
        string group = null;

        switch (groupNo)
        {
            case (int)Group.Navy:

                group = "Navy";
                break;

            case (int)Group.Land:

                group = "Land";
                break;

            case (int)Group.Air:

                group = "Air";
                break;
        }

        return group;
    } // Convert code to group name
}
