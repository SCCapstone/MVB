using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour
{

    // Use this for initialization
    //MVB Script
    public GameObject go;
    public GameObject empty;

    void Start()
    {
        //creating an emptuy object so i dont create a lot of new game objects
        empty = new GameObject();
        go = empty;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            //If controller points to canvas 2
            if (hit.collider.gameObject.name == "Canvas2")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("GreenSt_EXT");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            /*else if(hit.collider.gameObject.name =="Door")
            {
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }*/

            else if (hit.collider != null)
            {
                if (go != hit.collider.gameObject)
                {
                    go.SendMessage("OnDoorExit");
                    go = hit.transform.gameObject;
                    go.transform.SendMessage("OnDoorEnter");
                    Debug.Log("On VR Raycast Enter");
                }
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    go.transform.SendMessage("OnVRTriggerDown");
                }
                if (OVRInput.GetDown(OVRInput.Button.One))
                {

                }
                if (OVRInput.GetDown(OVRInput.Button.Two))
                {

                }
            }

            /* Hover over door, shows canvas, can push door down, need to work on fixing this
            if (hit.collider != null)
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
            }*/
        }
        else
        {
            if (go != null)
            {
                go.transform.SendMessage("OnDoorExit"/*SendMessageOptions.RequireReceiver*/);
                go = empty;
            }
        }
    }
}
