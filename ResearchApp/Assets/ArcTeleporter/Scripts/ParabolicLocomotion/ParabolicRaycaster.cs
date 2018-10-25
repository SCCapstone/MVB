using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicRaycaster : ArcRaycaster {
	[Tooltip("Initial velocity of projectile")]
	public float velocity = 10;
	[Tooltip("Initial acceleration of projectile")]
	public float acceleration = 9.8f;
	[Tooltip("Additional flight time allows parabola to dip below origin")]
	public float additionalFlightTime = 0.5f;
	[Tooltip("Number of segments used to check for collision\nSuggested to be 10% of visual parabola")]
	public int segments = 30;

	// Points of parabola
	protected List<Vector3> parabola = new List<Vector3> ();

	public float Angle {
		get {
			return Vector3.Angle (Forward, ControllerForward);
		}
	}

	public Vector3 Velocity {
		get {
			return ControllerForward * velocity;
		}
	}

	public Vector3 Acceleration {
		get {
			return Up * -1.0f * acceleration;
		}
	}

	public float FlightTime {
		get {
			float flightTime = 2.0f * velocity * Mathf.Sin (Angle * Mathf.Deg2Rad) / acceleration;
			return flightTime + additionalFlightTime;
		}
	}

	public float FlightDistance {
		get {
			return (velocity * velocity) * Mathf.Sin ((2.0f * Angle) * Mathf.Deg2Rad) / acceleration;
		}
	}

	public float HitTime { get; protected set; }

	public Vector3 SampleCurve(Vector3 p, Vector3 v, Vector3 a, float t) {
		Vector3 result = new Vector3 ();
		result.x = p.x + v.x * t + 0.5f * a.x * t * t;
		result.y = p.y + v.y * t + 0.5f * a.y * t * t;
		result.z = p.z + v.z * t + 0.5f * a.z * t * t;
		return result;
	}

	void Awake() {
		if (trackingSpace == null && OVRManager.instance != null) {
			GameObject cameraObject = OVRManager.instance.gameObject;
			trackingSpace = cameraObject.transform.Find ("TrackingSpace");
			Debug.LogWarning ("Tracking space not set for ParabolicRaycaster");
		}
		if (trackingSpace == null) {
			Debug.LogError ("Tracking MUST BE set for ParabolicRaycaster");
		}
	}

	void Update()
	{
		MakingContact = false;

		parabola.Clear();
		parabola.Add(Start);

		Vector3 last = Start;
		Vector3 v = Velocity;
		Vector3 a = Acceleration;

		RaycastHit hit;
		float recip = 1.0f / (float)(segments - 1);
		for(int i = 1; i < segments; i++) {
			float t = (float)i * recip;
			t *= FlightTime;

			Vector3 next = SampleCurve(Start, v, a, t);

			if (Physics.Linecast (last, next, out hit, ~excludeLayers)) {
				parabola.Add (hit.point);
				Normal = hit.normal;
				HitPoint = hit.point;

				float angle = Vector3.Angle(Vector3.up, hit.normal);
				if (angle < surfaceAngle) {

					HitTime = t;
					float adjust_distance = hit.distance / (last - next).magnitude;
					adjust_distance *= recip * FlightTime;
					HitTime += adjust_distance;

					MakingContact = true;
				}
				break;
			} else {
				parabola.Add (next);
			}

			last = next;
		}
	}
}