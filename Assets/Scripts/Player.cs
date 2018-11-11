using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

	[Tooltip("In ms^-1")][SerializeField] float speed = 4f;
	[Tooltip("In m")][SerializeField] float xRange = 10f;
	[Tooltip("In m")][SerializeField] float yRange = 10f;
	
	[SerializeField] float controlPitchFactor = -5f;
	[SerializeField] float controlRollFactor = -20f;
	[SerializeField] float posYawFactor = 5f;
	[SerializeField] float posPitchFactor = -20f;
	


	float xThrow, yThrow;
	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		ProcessTranslation();
		ProcessRotation();
	}
	void ProcessRotation() {
		float pitch = transform.localPosition.y * posPitchFactor + yThrow * controlPitchFactor;
		float yaw = transform.localPosition.x * posYawFactor;
		float roll = xThrow * controlRollFactor ;
		transform.localRotation = Quaternion.Euler(pitch,yaw,roll);
	}
	void ProcessTranslation() {
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");
		
		float xOffset = xThrow * speed * Time.deltaTime;
		float yOffset = yThrow * speed * Time.deltaTime;
		float rawNewX = transform.localPosition.x + xOffset;
		float newPosX = Mathf.Clamp(rawNewX,-xRange,xRange);
		float rawNewY = transform.localPosition.y + yOffset;

		float newPosY = Mathf.Clamp(rawNewY,-yRange,yRange);
		transform.localPosition = new Vector3(newPosX,newPosY,transform.localPosition.z);
	}
}
