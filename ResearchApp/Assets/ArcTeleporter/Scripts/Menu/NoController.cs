using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoController : MonoBehaviour {

	protected OVRInput.Controller left = OVRInput.Controller.LTrackedRemote;
	protected OVRInput.Controller right = OVRInput.Controller.RTrackedRemote;
	protected Canvas canvas = null;

	private bool m_prevControllerConnected = false;
	private bool m_prevControllerConnectedCached = false;

	void Awake() {
		canvas = GetComponent<Canvas> ();
	}

	void Update()
	{
		bool controllerConnected = OVRInput.IsControllerConnected(left) || OVRInput.IsControllerConnected(right);

		if ((controllerConnected != m_prevControllerConnected) || !m_prevControllerConnectedCached)
		{
			canvas.enabled = !controllerConnected;
			m_prevControllerConnected = controllerConnected;
			m_prevControllerConnectedCached = true;
		}

		if (!controllerConnected)
		{
			return;
		}
	}
}
