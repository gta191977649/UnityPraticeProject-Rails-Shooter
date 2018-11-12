using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Setup : MonoBehaviour {

	// Use this for initialization
	[SerializeField] int frameLimit = 60;
	void Awake () {
		//限制帧数
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = frameLimit;
	}
	
	// Update is called once per frame
	void Update () {
		if(Application.targetFrameRate != frameLimit)
              Application.targetFrameRate = frameLimit;
	}
}
