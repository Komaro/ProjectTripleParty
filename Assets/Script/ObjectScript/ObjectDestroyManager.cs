using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectDestroyManager{

    private static ObjectDestroyManager instance;

    public PointerEventData pointerEvent;
    //public GraphicRaycaster graphicRay;

    // Use this for initialization
    ObjectDestroyManager(){

        pointerEvent = new PointerEventData(null);
	}

    public static ObjectDestroyManager getInstance()
    {
        if(instance == null)
        {
            instance = new ObjectDestroyManager();
        }

        return instance;
    }

    public bool outClickDestroy(string tag, GraphicRaycaster graphicRay) { return outClickDestroyObject(tag, graphicRay); }
    private bool outClickDestroyObject(string tag, GraphicRaycaster graphicRay)
    {
        // http://www.devkorea.co.kr/bbs/board.php?bo_table=m03_qna&wr_id=77383
         
        pointerEvent.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        graphicRay.Raycast(pointerEvent, results);

        if (results.Count != 0)
        {
            GameObject obj = results[0].gameObject;

            // error ? check tag name
            //Debug.Log(obj.tag);
            if (!obj.CompareTag(tag))
            {
                return true;
            }
        }
        
        return false;
    }
}
