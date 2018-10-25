using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcRaycaster : MonoBehaviour {
	[Tooltip("Tracking space of OVRCameraRig, VR space is relative to this")]
	public Transform trackingSpace;
	[Tooltip("How manu angles from world up the surface can point and still be valid. Avoids casting onto walls.")]
	public float surfaceAngle = 5;
	[Tooltip("Any layers the raycast should not affect")]
	public LayerMask excludeLayers;

	// Raycasting is relative to tracking space, not world space
	public Vector3 Up { get { return trackingSpace.up; } }
	public Vector3 Right { get { return trackingSpace.right; } }
	public Vector3 Forward { get { return trackingSpace.forward; } }

	// Where the curve starts (usually at the controller)
	public Vector3 Start { get { return ControllerPosition; } }
	// Did the ray hit anything?
	public bool MakingContact { get; protected set; }
	// If it did, what was the normal
	public Vector3 Normal { get; protected set; }
	// Where the ray actually hit
	public Vector3 HitPoint { get; protected set; }

	public OVRInput.Controller Controller {
		get {
			OVRInput.Controller controller = OVRInput.GetConnectedControllers ();
			if ((controller & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote) {
				return OVRInput.Controller.LTrackedRemote;
			} else if ((controller & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote) {
				return OVRInput.Controller.RTrackedRemote;
			}
			return OVRInput.GetActiveController ();
		}
	}

	public Vector3 ControllerPosition {
		get {
			#if UNITY_EDITOR
			Debug.LogWarning("Controller position not available in editor");
			#endif
			Vector3 position = OVRInput.GetLocalControllerPosition (Controller);

			return trackingSpace.localToWorldMatrix.MultiplyPoint (position);
		}
	}

	public Vector3 ControllerForward {
		get {
			#if UNITY_EDITOR
			Debug.LogWarning("Controller orientation not available in editor");
			#endif
			Quaternion orientation = OVRInput.GetLocalControllerRotation (Controller);
			Vector3 worldForward = trackingSpace.localToWorldMatrix.MultiplyVector (orientation * Vector3.forward);

			return worldForward.normalized;
		}
	}

	public Vector3 ControllerUp {
		get {
			#if UNITY_EDITOR
			Debug.LogWarning("Controller orientation not available in editor");
			#endif
			Quaternion orientation = OVRInput.GetLocalControllerRotation (Controller);
			Vector3 worldForward = trackingSpace.localToWorldMatrix.MultiplyVector (orientation * Vector3.up);

			return worldForward.normalized;
		}
	}

	public Vector3 ControllerRight {
		get {
			#if UNITY_EDITOR
			Debug.LogWarning("Controller orientation not available in editor");
			#endif
			Quaternion orientation = OVRInput.GetLocalControllerRotation (Controller);
			Vector3 worldForward = trackingSpace.localToWorldMatrix.MultiplyVector (orientation * Vector3.right);

			return worldForward.normalized;
		}
	}
}
