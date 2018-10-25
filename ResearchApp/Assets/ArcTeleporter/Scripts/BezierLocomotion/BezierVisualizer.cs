using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierVisualizer : ArcVisualizer {
	protected BezierRaycaster raycaster;
	void Awake() {
		if (arcRenderer == null) {
			arcRenderer = GetComponent<LineRenderer> ();
		}
		if (arcRaycaster == null) {
			arcRaycaster = GetComponent<BezierRaycaster> ();
		}
		else if (!(arcRaycaster is BezierRaycaster)) {
			Debug.LogError ("BezierVisualizer's Arc Ray is not BezierRaycaster");
		}
		if (arcRenderer == null) {
			Debug.LogError ("BezierVisualizer's Line Renderer is not set");
		}
		if (arcRaycaster == null) {
			Debug.LogError ("BezierVisualizer's Arc Ray Caster is not set");
		}
		if (segments < 3) {
			segments = 3;
			Debug.LogWarning ("Should have at least 3 segments!");
		}

		arcRenderer.positionCount = segments;
		if (arcRaycaster != null) {
			raycaster = arcRaycaster as BezierRaycaster;
		}
	}

	void Update () {
		#if !UNITY_EDITOR
		if (EarlyOut()) {
			return;
		}
		#endif

		Vector3 end = raycaster.End;
		Vector3 control = raycaster.Control;

		float recip = 1.0f / (float)(segments - 1);
		for (int i = 0; i < segments; ++i) {
			float t = (float)i * recip;
			Vector3 sample = SampleCurve(arcRaycaster.Start, end, control, Mathf.Clamp01(t));
			arcRenderer.SetPosition (i, sample);
		}

		SetCurveVisuals ();
	}

	Vector3 SampleCurve(Vector3 start, Vector3 end, Vector3 control, float time) {
		return Vector3.Lerp(Vector3.Lerp(start, control, time), Vector3.Lerp(control, end, time), time);
	}
}