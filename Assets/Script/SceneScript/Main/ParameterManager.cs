using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Script.StartingWork.User;

public class ParameterManager : MonoBehaviour {

    public GameObject level;
    public GameObject fuel;
    public GameObject material;
    public GameObject ammunition;

    public int levelCount;
    public int fuelAmount;
    public int materialAmount;
    public int ammuntionAmount;

	// Use this for initialization
	void Start () {
        initializationParameter();

        level.GetComponent<Text>().text = levelCount.ToString();
        fuel.GetComponent<Text>().text = fuelAmount.ToString();
        material.GetComponent<Text>().text = materialAmount.ToString();
        ammunition.GetComponent<Text>().text = ammuntionAmount.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void initializationParameter()
    {
        levelCount = UserData.getInstance().User.level;
        fuelAmount = UserData.getInstance().User.fuel;
        materialAmount = UserData.getInstance().User.material;
        ammuntionAmount = UserData.getInstance().User.ammunition;
    }
}
