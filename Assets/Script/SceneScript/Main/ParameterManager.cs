using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.User;

public class ParameterManager : MonoBehaviour {

    public Text level;
    public Text fuel;
    public Text material;
    public Text ammunition;

    public int levelCount;
    public int fuelAmount;
    public int materialAmount;
    public int ammuntionAmount;

	// Use this for initialization
	void Start () {
        initializationParameter();

        level.text = levelCount.ToString();
        fuel.text = fuelAmount.ToString();
        material.text = materialAmount.ToString();
        ammunition.text = ammuntionAmount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void initializationParameter()
    {
        level = GameObject.Find("Level").GetComponent<Text>();
        fuel = GameObject.Find("FuelAmount").GetComponent<Text>();
        material = GameObject.Find("MaterialAmount").GetComponent<Text>();
        ammunition = GameObject.Find("AmmunitionAmount").GetComponent<Text>();

        levelCount = UserData.getInstance().User.level;
        fuelAmount = UserData.getInstance().User.fuel;
        materialAmount = UserData.getInstance().User.material;
        ammuntionAmount = UserData.getInstance().User.ammunition;
    }
}
