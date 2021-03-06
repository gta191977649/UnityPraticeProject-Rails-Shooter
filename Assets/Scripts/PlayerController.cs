﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerController : MonoBehaviour {

	[Tooltip("In ms^-1")][SerializeField] float speed = 4f;
	[Tooltip("In m")][SerializeField] float xRange = 10f;
	[Tooltip("In m")][SerializeField] float yRange = 10f;
	
	[SerializeField] float controlPitchFactor = -5f;
	[SerializeField] float controlRollFactor = -20f;
	[SerializeField] float posYawFactor = 5f;
	[SerializeField] float posPitchFactor = -20f;
	
	[SerializeField] GameObject[] guns;
	float xThrow, yThrow;
	bool isControlEnabled = true;
	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {
		if(isControlEnabled){
			ProcessTranslation();
			ProcessRotation();
			ProcessFiring();
		}
	}
	void ProcessFiring() {
		if(CrossPlatformInputManager.GetButton("Fire")){
			foreach(GameObject gun in guns) {
				gun.SetActive(true);
			}
		} else {
			foreach(GameObject gun in guns) {
				gun.SetActive(false);
			}
		}
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
	void OnPlayerDealth(){
		Debug.Log("FREAZED");
		isControlEnabled = false;
		gameObject.SetActive(false);
	}

}
