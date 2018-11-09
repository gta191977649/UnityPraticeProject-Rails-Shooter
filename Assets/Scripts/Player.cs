using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Player : MonoBehaviour {

	[Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
	[Tooltip("Range")][SerializeField] float range = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float xhorizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float xOffset = xhorizontalThrow * xSpeed * Time.deltaTime;
		float rawNewX = transform.localPosition.x + xOffset;
		float newPos = Mathf.Clamp(rawNewX,-range,range);
		transform.localPosition = new Vector3(newPos,transform.localPosition.y,transform.localPosition.z);

	}
}
