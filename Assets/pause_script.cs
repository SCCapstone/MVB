using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.CameraEditor;

public class pause_script : MonoBehaviour {

    public Transform Canvas;
    public Transform applyImg;
    public Transform Canvas_Set;
    private void Start()
    {

        Canvas.gameObject.SetActive(false);
        Canvas_Set.gameObject.SetActive(false);
        applyImg.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause_function();
            

        }
    
	}
    public void pause_function()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {

            Canvas.gameObject.SetActive(true);
            Canvas_Set.gameObject.SetActive(false);

            Time.timeScale = 0;
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Canvas_Set.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void setting_function()
    {
        if (Canvas_Set.gameObject.activeInHierarchy == false)
        {
            Canvas_Set.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            applyImg.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
        else 
        {
            Canvas_Set.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);

        }

    }
    public void ba_bu_func()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Canvas_Set.gameObject.SetActive(false);
            Canvas.gameObject.SetActive(true);

            Time.timeScale = 0;
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Canvas_Set.gameObject.SetActive(true);

        }
    }
    public void apply_func()
    {
        if (applyImg.gameObject.activeInHierarchy == false)
        {
            applyImg.gameObject.SetActive(true);

        }
    }

}
