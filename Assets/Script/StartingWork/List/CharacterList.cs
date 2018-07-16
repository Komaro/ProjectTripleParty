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
    
    private void createCharacterList()
    {
        List<Dictionary<string, object>> characterList = CSVManager.Read("Character/CharacterList");
        
        for(int i = 0; i < characterList.Count; i++)
        {
            Characters.Add(new CharacterForm((int)characterList[i]["no"],
                                             characterList[i]["name"].ToString(),
                                             (int)characterList[i]["image"], 
                                             switchCountry((int)characterList[i]["country"]),
                                             switchGroup((int)characterList[i]["group"])));
        }
    }// Read character data(csv)

    private string switchCountry(int countryNo)
    {
        string country = null;

        switch(countryNo)
        {
            case 0:

                country = "미정";
                break;

            case 1:

                country = "USA";
                break;

            case 2:

                country = "미정";
                break;

            case 3:

                country = "영국";
                break;

            default:

                country = "미정";
                break;
        }

        return country;
    } // Convert code to country name
    private string switchGroup(int groupNo)
    {
        string group = null;

        switch (groupNo)
        {
            case 0:

                group = "Navy";
                break;

            case 1:

                group = "Land";
                break;

            case 2:

                group = "Air";
                break;
        }

        return group;
    } // Convert code to group name
}
