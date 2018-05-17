using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.ObjectScript;

public class ArmyButtonClick : MonoBehaviour {

    public void onClick()
    {
        gameObject.AddComponent<ArmyButtonMenuPanel>().ArmyButtonClick(gameObject);
    }
}
