using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {
	UnityEngine.SceneManagement.Scene scene;

	void Start () {
		scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
	}
	
	void Update () {
		if (Input.GetButtonDown ("Cancel")) {
			if (scene.name != "Start") {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("Start", UnityEngine.SceneManagement.LoadSceneMode.Single);
			}
		}
	}

	public void OnSelect(Transform t) {
		string name = t.gameObject.name;
		UnityEngine.SceneManagement.SceneManager.LoadScene (name, UnityEngine.SceneManagement.LoadSceneMode.Single);
	}

}
