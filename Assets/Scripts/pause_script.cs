using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//using static UnityEditor.CameraEditor;

public class pause_script : MonoBehaviour {

    public Transform PCanvas;
  

    private void Start()
    {

        PCanvas.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update () {
        OVRInput.Update();
  
    }
    public void pause_function()
    {
        if (PCanvas.gameObject.activeInHierarchy == false)
        {

            PCanvas.gameObject.SetActive(true);
            //Canvas_Set.gameObject.SetActive(false);

            Time.timeScale = 0;
        }
        else
        {
           PCanvas.gameObject.SetActive(false);
            //Canvas_Set.gameObject.SetActive(false);
            //Time.timeScale = 1;
        }
    }
    public void res_function()
    {
        PCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ba_bu_func()
    {
        if (PCanvas.gameObject.activeInHierarchy == false)
        {
            //Canvas_Set.gameObject.SetActive(false);
            PCanvas.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            PCanvas.gameObject.SetActive(false);
            //Canvas_Set.gameObject.SetActive(true);

        }
    }
    
}
