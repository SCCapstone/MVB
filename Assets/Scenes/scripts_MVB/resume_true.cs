using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resume_true : MonoBehaviour
{

    public Transform PCanvas;
    // Use this for initialization
    public void res_function2()
    {
        PCanvas.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
