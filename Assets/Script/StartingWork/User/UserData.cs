using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Script.StartingWork.User;

public class UserData{

    private static UserData Instance;

    public String beforeScene
    {
        get;
        set;
    }

    public UserForm User;
    private List<List<int>> fleetFormation;
    
    public static UserData getInstance()
    {
        if(Instance == null)
        {
            Instance = new UserData();
        }

        return Instance;
    }

    public UserData()
    {
        beforeScene = null;

        uploadUserData();
        uploadFleetFormation();
    }

    public void uploadUserData()
    {
        List<Dictionary<string, object>> loadUserData = CSVManager.Read("User/UserInformation");

        User = new UserForm((int)loadUserData[0]["usercode"],
                            (int)loadUserData[0]["level"],
                            (int)loadUserData[0]["fuel"],
                            (int)loadUserData[0]["material"],
                            (int)loadUserData[0]["ammunition"]);
    } // Load User/UserInformation.csv
    public void uploadFleetFormation()
    {
        fleetFormation = new List<List<int>>();

        List<Dictionary<string, object>> loadFleetFormation = CSVManager.Read("User/FleetFormation");

        if(loadFleetFormation[0]["fleet"].Equals("/end"))
        {
            return;
        }
        
        for (int i = 0; i < loadFleetFormation.Count; i++)
        {
            int shipNum = 0;
            fleetFormation.Add(new List<int>());

            while (!loadFleetFormation[i]["ship" + ++shipNum].Equals("end"))
            {
                fleetFormation[i].Add((int)loadFleetFormation[i]["ship" + shipNum]);
                //Debug.Log(loadFleetFormation[i]["ship" + shipNum]);
            }
        }
    }// Load User/FleetFormation.csv

    public List<List<int>> getFleetFormation()
    {
        return fleetFormation;
    } 
}
