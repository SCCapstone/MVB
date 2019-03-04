using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour {

    // Use this for initialization
    //MVB Script
    public GameObject go;
    public GameObject empty;
    
	void Start () {
        //creating an emptuy object so i dont create a lot of new game objects
        empty = new GameObject();
        go = empty;
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider != null)
            {
                if(go != hit.collider.gameObject)
                {
                    go.SendMessage("OnDoorExit");
                    go = hit.transform.gameObject;
                    go.transform.SendMessage("OnDoorEnter");
                    Debug.Log("On VR Raycast Enter");
                }
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    go.transform.SendMessage("OnVRTriggerDown");
                }
                if(OVRInput.GetDown(OVRInput.Button.One))
                {

                }
                if(OVRInput.GetDown(OVRInput.Button.Two))
                {

                }
            }
        }
        else
        {
            if(go != null)
            {
                go.transform.SendMessage("OnDoorExit"/*SendMessageOptions.RequireReceiver*/);
                go = empty;
            }
        }
	}
}
