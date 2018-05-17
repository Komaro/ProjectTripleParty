using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupNavyMenuDestroy : MonoBehaviour {

    private void OnDestroy()
    {
        gameObject.transform.parent.GetComponent<Button>().enabled = true;
    }
}
