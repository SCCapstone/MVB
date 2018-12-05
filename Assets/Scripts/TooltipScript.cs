using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TooltipScript : MonoBehaviour {

    public Text helpText;
    public Text tooltipText;

    public string helpString;
    public string tooltipString;

	// Use this for initialization
	void Start () {
        helpText = GameObject.Find("HelpText").GetComponent<Text>();
        tooltipText = GameObject.Find("TooltipText").GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDoorEnter() //updates to inform user he/she is pointing at door
    {
        helpText.text = helpString;
        tooltipText.text = tooltipString;
    }
    
    void OnDoorExit()
    {
        helpText.text = "";
        tooltipText.text = "";
    }
}
