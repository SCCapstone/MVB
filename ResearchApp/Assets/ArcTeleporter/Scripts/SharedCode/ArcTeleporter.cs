using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcTeleporter : MonoBehaviour {
	public enum UpDirection { World, TargetNormal};

	[Tooltip("Raycaster used for teleportation")]
	public ArcRaycaster arcRaycaster;
	[Tooltip("What object to teleport")]
	public Transform objectToMove;

	[Tooltip("Height of object being teleported. How far off the ground the object should land.")]
	public float height = 1.29f;
	[Tooltip("When teleporting, should object be aligned with the world or destination")]
	public UpDirection teleportedUpAxis = UpDirection.World;

	// Used to buffer trigger
	protected bool lastTriggerState = false;

	void Awake() {
		if (arcRaycaster == null) {
			arcRaycaster = GetComponent<ArcRaycaster> ();
		}
		if (arcRaycaster == null) {
			Debug.LogError ("ArcTeleporter's Arc Ray Caster is not set");
		}
		if (objectToMove == null) {
			Debug.LogError ("ArcTeleporter's target object is not set");
		}
	}

	void Update () {
		if (!HasController) {
			return; 
		}

		bool currentTriggerState = OVRInput.Get (OVRInput.Button.PrimaryIndexTrigger);

		// If the trigger was released this frame
		if (lastTriggerState && !currentTriggerState) {
			Vector3 forward = objectToMove.forward;
			Vector3 up = Vector3.up;

			// If there is a valid raycast
			if (arcRaycaster!= null && arcRaycaster.MakingContact) {
				if (objectToMove != null) {
					if (teleportedUpAxis == UpDirection.TargetNormal) {
						up = arcRaycaster.Normal;
					}
					objectToMove.position = arcRaycaster.HitPoint + up * height;
				}
			}

			if (OVRInput.Get (OVRInput.Touch.PrimaryTouchpad)) {
				forward = TouchpadDirection;
			}

			objectToMove.rotation = Quaternion.LookRotation (forward, up);
		}

		lastTriggerState = currentTriggerState;
	}

	OVRInput.Controller Controller {
		get {
			OVRInput.Controller controllers = OVRInput.GetConnectedControllers ();
			if ((controllers & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote) {
				return OVRInput.Controller.LTrackedRemote;
			}
			if ((controllers & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote) {
				return OVRInput.Controller.RTrackedRemote;
			}
			return OVRInput.Controller.None;
		}
	}

	bool HasController {
		get {
			OVRInput.Controller controllers = OVRInput.GetConnectedControllers ();
			if ((controllers & OVRInput.Controller.LTrackedRemote) == OVRInput.Controller.LTrackedRemote) {
				return true;
			}
			if ((controllers & OVRInput.Controller.RTrackedRemote) == OVRInput.Controller.RTrackedRemote) {
				return true;
			}
			return false;
		}
	}

	Matrix4x4 ControllerToWorldMatrix {
		get {
			if (!HasController) {
				return Matrix4x4.identity;
			}

			Matrix4x4 localToWorld = arcRaycaster.trackingSpace.localToWorldMatrix;

			Quaternion orientation = OVRInput.GetLocalControllerRotation(Controller);
			Vector3 position = OVRInput.GetLocalControllerPosition (Controller);

			Matrix4x4 local = Matrix4x4.TRS (position, orientation, Vector3.one);

			Matrix4x4 world = local * localToWorld;

			return world;
		}
	}

	Vector3 TouchpadDirection {
		get {
			Vector2 touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
			Vector3 forward = new Vector3 (touch.x, 0.0f, touch.y).normalized;
			forward = ControllerToWorldMatrix.MultiplyVector (forward);
			forward = Vector3.ProjectOnPlane (forward, Vector3.up);
			return forward.normalized;
		}
	}
}
