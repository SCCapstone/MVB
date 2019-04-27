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
    public AudioSource DoorSound;
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
            if (hit.collider.gameObject.name == "StartCanvas")
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
            //All of the following code corresponds to reset and go out of maze
            //This lines corresponds to williams brice quiz maze/sample maze 2
            else if (hit.collider.gameObject.name == "Canvas3")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_2");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvas4")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_2");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvas5")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_2");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            if (hit.collider.gameObject.name == "Canvas2_back_scene")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("Williams-Brice_EXT");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }

            //lines corresponds to sample_maze_3
            else if (hit.collider.gameObject.name == "Canvasb3")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_3");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvasb4")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_3");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvasb5")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_3");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            if (hit.collider.gameObject.name == "Canvas2_back_scene2")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("Williams-Brice_EXT");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }

            //sample maze_4
            else if (hit.collider.gameObject.name == "Canvasc3")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_4");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvasc4")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_4");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvasc5")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("sample_maze_4");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            if (hit.collider.gameObject.name == "Canvas2_back_scene3")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("Williams-Brice_EXT");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }

            //line of code swng quiz maze
            else if (hit.collider.gameObject.name == "Canvas3_sw")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("maze_swng_quiz");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvas4_sw")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("maze_swng_quiz");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            else if (hit.collider.gameObject.name == "Canvas5_sw")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("maze_swng_quiz");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }
            if (hit.collider.gameObject.name == "Canvas2_back_scene_sw")
            {
                //shows in console controller can detect canvas2
                Debug.Log("HERE");


                //loads scene from Scene manager on OVRInput trigger down
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    SceneManager.LoadScene("SWGNHall_INT");
                    go.transform.SendMessage("OnVRTriggerDown");
                }
            }


            /*  else if(hit.collider.gameObject.name =="Door")
              {
                  Debug.Log("Door Hit");
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
