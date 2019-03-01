using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeOnClick : MonoBehaviour
{

    public Transform PCanvas;
    // Use this for initialization
    public void res_function()
    {
        PCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
