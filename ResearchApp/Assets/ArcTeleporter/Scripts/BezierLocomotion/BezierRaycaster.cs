using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierRaycaster : ArcRaycaster {
	[Tooltip("Horizontal distance of end point from controller")]
	public float distance = 15.0f;
	[Tooltip("Vertical of end point from controller")]
	public float dropHeight = 5.0f;
	[Tooltip("Height of bezier control (0 is at mid point)")]
	public float controlHeight = 5.0f;
	[Tooltip("How many segments to use for curve, must be at least 3. More segments = better quality")]
	public int segments = 10;

	// Where the curve ends
	public Vector3 End { get; protected set; }

	public Vector3 Control {
		get {
			Vector3 midPoint = Start + (End - Start) * 0.5f;
			return midPoint + ControllerUp * controlHeight;
		}
	}

	void Awake() {
		if (trackingSpace == null && OVRManager.instance != null) {
			GameObject cameraObject = OVRManager.instance.gameObject;
			trackingSpace = cameraObject.transform.Find ("TrackingSpace");
			Debug.LogWarning ("Tracking space not set for BezierRaycaster");
		}
		if (trackingSpace == null) {
			Debug.LogError ("Tracking MUST BE set for BezierRaycaster");
		}
	}

	void Update () {
		MakingContact = false;
		End = HitPoint = ControllerPosition + ControllerForward * distance + (ControllerUp * -1.0f) * dropHeight;

		RaycastHit hit;
		Vector3 last = Start;
		float recip = 1.0f / (float)(segments - 1);

		for (int i = 1; i < segments; ++i) {
			float t = (float)i * recip;
			Vector3 sample = SampleCurve(Start, End, Control, Mathf.Clamp01(t));

			if (Physics.Linecast(last, sample, out hit, ~excludeLayers)) {
				float angle = Vector3.Angle(Vector3.up, hit.normal);
				if (angle < surfaceAngle) {
					HitPoint = hit.point;
					Normal = hit.normal;
					MakingContact = true;
				}
			}

			last = sample;
		}

	}

	Vector3 SampleCurve(Vector3 start, Vector3 end, Vector3 control, float time) {
		return Vector3.Lerp(Vector3.Lerp(start, control, time), Vector3.Lerp(control, end, time), time);
	}
}
