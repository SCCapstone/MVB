using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorTest : MonoBehaviour
{
    public Button changeScene;
    // Start is called before the first frame update
    void Start()
    {
        Button button = changeScene;
        button.onClick.AddListener(buttonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClick()
    {
        Debug.Log("Button Clicked! Changing scenes...");
        Scene newScene = SceneManager.CreateScene("MainMenu");
        SceneManager.SetActiveScene(newScene);
        Debug.Log("New Scene: " + SceneManager.GetActiveScene().name);
    }
}
