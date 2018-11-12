using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggerScript : MonoBehaviour {

	[SerializeField] Text FpsLabel;
	public float updateTime = 200;

	// Update is called once per frame
	void Update () {
		updateTime += (Time.deltaTime - updateTime) * 0.1f;
		float fps = 1.0f / updateTime;
		FpsLabel.text = "FPS: "+Mathf.Ceil (fps).ToString ();
	}
}
