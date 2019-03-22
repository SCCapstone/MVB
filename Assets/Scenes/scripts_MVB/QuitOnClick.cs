using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
        //Quits Application without checking to see if if Unity Editor. Unity Editor will not be used in Oculus Go anyway. 
        //This was the root cause of the menu crash.
        Application.Quit();
        //#if UNITY_EDITOR
        //  UnityEditor.EditorApplication.isPlaying = false;
        //#else

        //#endif
    }
}

