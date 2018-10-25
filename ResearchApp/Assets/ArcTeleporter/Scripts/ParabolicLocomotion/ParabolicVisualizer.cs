using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicVisualizer : ArcVisualizer {
	protected ParabolicRaycaster raycaster;

	void Awake() {
		if (arcRenderer == null) {
			arcRenderer = GetComponent<LineRenderer> ();
		}
		if (arcRaycaster == null) {
			arcRaycaster = GetComponent<ParabolicRaycaster> ();
		} 
		else if (!(arcRaycaster is ParabolicRaycaster)) {
			Debug.LogError ("ParabolicVisualizer's Arc Ray is not ParabolicRaycaster");
		}
		if (arcRenderer == null) {
			Debug.LogError ("ParabolicVisualizer's Line Renderer is not set");
		}
		if (arcRaycaster == null) {
			Debug.LogError ("ParabolicVisualizer's Arc Ray Caster is not set");
		}
		if (segments < 3) {
			segments = 3;
			Debug.LogWarning ("Should have at least 3 segments!");
		}

		arcRenderer.positionCount = segments;
		if (arcRaycaster != null) {
			raycaster = arcRaycaster as ParabolicRaycaster;
		}
	}

	void Update () {
		#if !UNITY_EDITOR
		if (EarlyOut()) {
			return;
		}
		/* #else // Draw debug info
		float distance = (arcRaycaster.velocity * arcRaycaster.velocity) * Mathf.Sin ((2.0f * arcRaycaster.Angle) * Mathf.Deg2Rad) / arcRaycaster.acceleration;
		Vector3 dir = Vector3.ProjectOnPlane(arcRaycaster.ControllerForward, Vector3.up);
		Debug.DrawLine (arcRaycaster.Start, arcRaycaster.Start + dir.normalized * 500, Color.blue);
		Vector3 point = arcRaycaster.Start + dir.normalized * distance;
		Debug.DrawLine (point + Vector3.up, point - Vector3.up, Color.red); */
		#endif

		arcRenderer.SetPosition (0, arcRaycaster.Start);
		Vector3 v = raycaster.Velocity;
		Vector3 a = raycaster.Acceleration;
		float recip = 1.0f / (float)(segments - 1);
		for(int i = 1; i < segments; i++) {
			float t = (float)i * recip;
			t *= raycaster.FlightTime;

			if (t > raycaster.HitTime) {
				t = raycaster.HitTime;
			}

			arcRenderer.SetPosition (i, raycaster.SampleCurve(arcRaycaster.Start, v, a, t));
		}

		SetCurveVisuals ();
	}
}
