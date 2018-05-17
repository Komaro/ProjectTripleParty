using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.ObjectScript;

public class ArmyButtonClick : MonoBehaviour {

    public void onClick()
    {
        switch (gameObject.tag)
        {
            case "Navy":

                gameObject.AddComponent<ArmyButtonMenuPanel>().NavyButtonClick(gameObject);
                Debug.Log("Navy button click and Create panel");
                break;


                // no complete
            case "Land":

                gameObject.AddComponent<ArmyButtonMenuPanel>().NavyButtonClick(gameObject);
                Debug.Log("Land button click and Create panel");
                break;

            case "Air":

                gameObject.AddComponent<ArmyButtonMenuPanel>().NavyButtonClick(gameObject);
                Debug.Log("Air button click and Create panel");
                break;

            default:

                Debug.Log("button not click");
                break;
        }
    }
}
