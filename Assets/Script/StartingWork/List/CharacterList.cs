using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.Script.StartingWork.List;
using Assets.Script.DB;
using System.Data;
using System.IO;

public class CharacterList{

    private static CharacterList instance;

    private List<CharacterForm> Characters = new List<CharacterForm>();

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
    }

    private void createCharacterList()
    {
        IDataReader reader = DBmanager.getInstance().loadDirectory();

        while(reader.Read())
        {
            Characters.Add(new CharacterForm(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), switchCountry(reader.GetInt32(3))));
        }
    }
    
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
    }
}
